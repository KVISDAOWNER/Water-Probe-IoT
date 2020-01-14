#include <SigFox.h>
#include <ArduinoLowPower.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#include <ArduinoUnit.h>

#define ONE_WIRE_BUS 6
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);

const int turbidityPin = A1;
const int ph_pin = A0;

// Normal values that are used to find how extreme measurements are
const int ph_normal = 7;
const int turbidity_normal = 2;
const int temperature_normal = 18;
const int nitrogen_normal = 128;
const int phosphorus_normal = 128;

// This is how many measurements we make
const int measurements = 16;

int measurementIndices[5];
int measuredValues[9];

void setup() {
  sensors.begin(); 

  if (!SigFox.begin()){ 
    Serial.begin(9600); // Initiate the terminal
    Serial.print("Sigfox module did not start properly!"); // If the Sigfox-module cannot start properly, print an error message
    Serial.end();
  }
  SigFox.end();
  while (!Serial) {}
}

void loop(){
  Test::run(); 
}

float readTurbidity() {
  int sensorValue = 0;
  unsigned long int avgValue;
  float b;
  int buf[10], temp;
  for (int i = 0; i < 10; i++)
  {
    buf[i] = analogRead(turbidityPin);
    //delay(30);
  }
  for (int i = 0; i < 9; i++)
  {
    for (int j = i + 1; j < 10; j++)
    {
      if (buf[i] > buf[j])
      {
        temp = buf[i];
        buf[i] = buf[j];
        buf[j] = temp;
      }
    }
  }
  avgValue = 0;
  for (int i = 2; i < 8; i++)
    avgValue += buf[i];
  float turbidity = (float)avgValue * 3.3 / 1024 / 6;
  //Serial.println(turbidity);
  return turbidity;
}

float readpH() {
  float offset = 16; //change this value to calibrate
  int sensorValue = 0;
  unsigned long int avgValue;
  float b;
  int buf[10], temp;
  for (int i = 0; i < 10; i++)
  {
    buf[i] = analogRead(ph_pin);
    //delay(30);
  }
  for (int i = 0; i < 9; i++)
  {
    for (int j = i + 1; j < 10; j++)
    {
      if (buf[i] > buf[j])
      {
        temp = buf[i];
        buf[i] = buf[j];
        buf[j] = temp;
      }
    }
  }
  avgValue = 0;
  for (int i = 2; i < 8; i++)
    avgValue += buf[i];
  float pHVol = (float)avgValue * 3.3 / 1024 / 6;
  float phValue = -5.70 * pHVol + offset;
  //Serial.println(phValue);
  return phValue;
}

float readTemp() {
  sensors.requestTemperatures();
  float temperature = sensors.getTempCByIndex(0) - 5;
  //Serial.println(temperature);
  return temperature;
}

float readNitrogen() {
  float result = (float)random(255);
  //Serial.println(result);
  return result;
}

float readPhosphorus() {
  float result = (float)random(255);
  //Serial.println(result);
  return result;
}

byte byteClamp(float minValue, float maxValue, float value) {
  if (value < minValue)
    return (byte)254;
  else if (value > maxValue)
    return (byte)255;
  else
    return (byte)((value - minValue) * 253 / (maxValue - minValue));
}

void computeMeasurements(){
  float extremePh = ph_normal;
  float extremeTurbidity = turbidity_normal;
  float extremeTemperature = temperature_normal;
  float extremeNitrogen = nitrogen_normal;
  float extremePhosphorus = phosphorus_normal;
  
  int pHIndex = 0;
  int turbidityIndex = 0;
  int temperatureIndex = 0;
  int nitrogenIndex = 0;
  int phosphorusIndex = 0;
  
  for (int i = 0; i < measurements; ++i) {
    //Make measurements
    float turbidity = readTurbidity();
    float pH = readpH();
    float temperature = readTemp();
    float nitrogen = readNitrogen();
    float phosphorus = readPhosphorus();

    //Check if any of the new measurements are more extreme than the previous measurements made this message cycle.
    tryReplaceExtremeValue(turbidity, turbidity_normal, &extremeTurbidity, &turbidityIndex, i);
    tryReplaceExtremeValue(pH, ph_normal, &extremePh, &pHIndex, i);
    tryReplaceExtremeValue(temperature, temperature_normal, &extremeTemperature, &temperatureIndex, i);
    tryReplaceExtremeValue(nitrogen, nitrogen_normal, &extremeNitrogen, &nitrogenIndex, i);
    tryReplaceExtremeValue(phosphorus, phosphorus_normal, &extremePhosphorus, &phosphorusIndex, i);
  }
  measurementIndices[0] = pHIndex;
  measurementIndices[1] = turbidityIndex;
  measurementIndices[2] = temperatureIndex;
  measurementIndices[3] = nitrogenIndex;
  measurementIndices[4] = phosphorusIndex;
  
  measuredValues[0] = byteClamp(5, 9, extremePh);
  measuredValues[1] = byteClamp(0, 3, extremeTurbidity);
  measuredValues[2] = byteClamp(-10, 30, extremeTemperature);
  measuredValues[3] = byteClamp(0, 255, extremeNitrogen);
  measuredValues[4] = byteClamp(0, 255, extremePhosphorus);
  measuredValues[5] = (byte)0;  //Battery
  measuredValues[6] = (byte)(pHIndex * 16 + turbidityIndex); //This trick allows us to store two indices in one byte.
  measuredValues[7] = (byte)(temperatureIndex * 16 + nitrogenIndex);
  measuredValues[8] = (byte)phosphorusIndex * 16;
}

void tryReplaceExtremeValue(float value, float normalValue, float *extremeMeasurement,int *measurementIndex, int index){
  if (abs(value - normalValue) > abs(*extremeMeasurement - normalValue)) {
      *extremeMeasurement = value;
      *measurementIndex = index;
  }
}

test(byteClamp1){ // If the value is higher than the maximum value, return 255.
  // Arrange
  float minValue = 0;
  float maxValue = 1;
  float value = 2;
  
  // Act
  byte result = byteClamp(minValue, maxValue, value);
  
  // Assert
  assertEqual(255,result);
}

test(byteClamp2){ // If the value is below the minimum value, return 254.
  // Arrange
  float minValue = 0;
  float maxValue = 1;
  float value = -1;
  
  // Act
  byte result = byteClamp(minValue, maxValue, value);
  
  // Assert
  assertEqual(254,result);
}

test(byteClamp3){ // If the value is equal to the top of the range, return 253.
  // Arrange
  float minValue = 0;
  float maxValue = 1;
  float value = 1;
  
  // Act
  byte result = byteClamp(minValue, maxValue, value);
  
  // Assert
  assertEqual(253,result);
}

test(byteClamp4){ // If the value is equal to the bottom of the range, return 0.
  // Arrange
  float minValue = 0;
  float maxValue = 1;
  float value = 0;
  
  // Act
  byte result = byteClamp(minValue, maxValue, value);
  
  // Assert
  assertEqual(0,result);
}

test(byteClamp5){ // If the value is in the middle of the range, the value should be 126.5,
                  // which is rounded off to 126.
  // Arrange
  float minValue = 0;
  float maxValue = 1;
  float value = 0.5;
  
  // Act
  byte result = byteClamp(minValue, maxValue, value);
  
  // Assert
  assertEqual(126,result);
}

test(readTurbidity1){ // range of turbidity should be 0-3.3.
  // Arrange
  // Act
  float turbidity = readTurbidity();

  // Assert
  assertLessOrEqual(0,turbidity);
  assertLessOrEqual(turbidity,3.3);
}

test(readpH1){ // range of pH should be 0-14
  // Arrange
  // Act
  float pH = readpH();

  // Assert
  assertLessOrEqual(0, pH);
  assertLessOrEqual(pH, 14);
}

test(readTemperature1){ //range of temperature should be -10-30.
  // Arrange
  // Act
  float temperature = readTemp();

  // Assert
  assertLessOrEqual(-10, temperature);
  assertLessOrEqual(temperature, 30);
}

test(readNitrogen1){ // range of nitrogen should be 0-255.
  // Arrange
  // Act
  float nitrogen = readNitrogen();
  
  // Assert
  assertLessOrEqual(0,nitrogen);
  assertLessOrEqual(nitrogen,255);
}

test(readPhosphorus1){ // Range of phosphorus should be 0-255.
  // Arrange
  // Act
  float phosphorus = readPhosphorus();
  
  // Assert
  assertLessOrEqual(0,phosphorus);
  assertLessOrEqual(phosphorus,255);
}

test(measurementIndices1){ // All measurement indices are no higher than 15.
  // Arrange
  // Act
  computeMeasurements();

  // Assert
  for (int i = 0; i < 5; ++i){
    assertLessOrEqual(0,measurementIndices[i]);
    assertLessOrEqual(measurementIndices[i],15);
  }
}

test(byteClamppH1){// Test resulting value from a common pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5,9,6.6);

  // Assert
  assertEqual(101,pHByte);
}

test(byteClamppH2){ // Test resulting value from a common pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5,9,8.6);

  // Assert
  assertEqual(227,pHByte);
}

test(byteClamppH3){ // Test resulting value from a too low pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5 ,9, 4.7);

  // Assert
  assertEqual(254,pHByte);
}

test(byteClamppH4){ // Test resulting value from a too high pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5, 9, 9.7);

  // Assert
  assertEqual(255,pHByte);
}

test(byteClamppH5){ // Test resulting value from a high pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5,9,9);

  // Assert
  assertEqual(253,pHByte);
}

test(byteClamppH6){ // Test resulting value from a low pH value.
  // Arrange 
  // Act
  byte pHByte = byteClamp(5,9,5);

  // Assert
  assertEqual(0,pHByte);
}

test(byteClampTemperature1){// Test resulting value from a common temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,22);

  // Assert
  assertEqual(temperatureByte,202);
}

test(byteClampTemperature2){// Test resulting value from a common temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,5);

  // Assert
  assertEqual(temperatureByte,94);
}

test(byteClampTemperature3){// Test resulting value from a too low temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,-11);

  // Assert
  assertEqual(temperatureByte,254);
}

test(byteClampTemperature4){// Test resulting value from a too high temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,41);

  // Assert
  assertEqual(temperatureByte,255);
}

test(byteClampTemperature5){// Test resulting value from a high temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,30);

  // Assert
  assertEqual(temperatureByte,253);
}

test(byteClampTemperature6){// Test resulting value from a low temperature value.
  // Arrange
  // Act
  byte temperatureByte = byteClamp(-10,30,-10);

  // Assert
  assertEqual(temperatureByte,0);
}

test(byteClampturbidity1){// Test resulting value from a common turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,1.8);

  // Assert
  assertEqual(turbidityByte,151);
}

test(byteClampturbidity2){// Test resulting value from a common turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,0.2);

  // Assert
  assertEqual(turbidityByte,16);
}

test(byteClampturbidity3){// Test resulting value from a too high turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,4);

  // Assert
  assertEqual(turbidityByte,255);
}

test(byteClampturbidity4){// Test resulting value from a too low turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,-1);

  // Assert
  assertEqual(turbidityByte,254);
}

test(byteClampturbidity5){// Test resulting value from a low turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,0);

  // Assert
  assertEqual(turbidityByte,0);
}

test(byteClampturbidity6){// Test resulting value from a high turbidity value.
  // Arrange
  // Act
  byte turbidityByte = byteClamp(0,3,3);

  // Assert
  assertEqual(turbidityByte,253);
}

test(tryReplace1){// Test tryReplaceExtremeValue. value is more extreme.
  // Arrange
  float value = 4;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,4);
  assertEqual(measurementIndex,2);
}

test(tryReplace2){// Test tryReplaceExtremeValue. value is as extreme.
  // Arrange
  float value = 5;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,5);
  assertEqual(measurementIndex,1);
}

test(tryReplace3){// Test tryReplaceExtremeValue. value is less extreme.
  // Arrange
  float value = 6;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,5);
  assertEqual(measurementIndex,1);
}

test(tryReplace4){// Test tryReplaceExtremeValue. value is more extreme, but in the other direction.
  // Arrange
  float value = 15;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,15);
  assertEqual(measurementIndex,2);
}

test(tryReplace5){// Test tryReplaceExtremeValue. value is as extreme, but in the other direction.
  // Arrange
  float value = 13;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,5);
  assertEqual(measurementIndex,1);
}

test(tryReplace6){// Test tryReplaceExtremeValue. value is less extreme, but in the other direction.
  // Arrange
  float value = 11;
  float extremeValue = 5;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,5);
  assertEqual(measurementIndex,1);
}

test(tryReplace7){// Test tryReplaceExtremeValue. value is a little less extreme
  // Arrange
  float value = 11;
  float extremeValue = 6;
  float normalValue = 9;
  int measurementIndex = 1;
  int index = 2;
  
  // Act
  tryReplaceExtremeValue(value, normalValue, &extremeValue, &measurementIndex, index);
  
  // Assert
  assertEqual(extremeValue,6);
  assertEqual(measurementIndex,1);
}
