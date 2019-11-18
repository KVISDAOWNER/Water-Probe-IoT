#include <SigFox.h>
#include <ArduinoLowPower.h>
#include <OneWire.h>
#include <DallasTemperature.h>

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

void setup() {
  sensors.begin(); 

  if (!SigFox.begin()){ 
    Serial.begin(9600); // Initiate the terminal
    Serial.print("Sigfox module did not start properly!"); // If the Sigfox-module cannot start properly, print an error message
    Serial.end();
  }
  SigFox.end();
}

void loop() {
  // All of these are storage for the most extreme values
  float extremePh = ph_normal;
  float extremeTurbidity = turbidity_normal;
  float extremeTemperature = temperature_normal;
  float extremeNitrogen = nitrogen_normal;
  float extremePhosphorus = phosphorus_normal;

  //Here we store which indices of the measurements was the most extreme.
  //This helps us find the time of the measurement.
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
    // Delay such that a whole cycle takes about 15 minutes (or 900,000 milliseconds)
    LowPower.sleep(900000 / measurements);
  }

  byte values[9];
  // Put everything into an array
  values[0] = byteClamp(5, 9, extremePh);
  values[1] = byteClamp(0, 3, extremeTurbidity);
  values[2] = byteClamp(-10, 30, extremeTemperature);
  values[3] = byteClamp(0, 255, extremeNitrogen);
  values[4] = byteClamp(0, 255, extremePhosphorus);
  values[5] = (byte)0;  //Battery
  values[6] = (byte)(pHIndex * 16 + turbidityIndex); //This trick allows us to store two indices in one byte.
  values[7] = (byte)(temperatureIndex * 16 + nitrogenIndex);
  values[8] = (byte)phosphorusIndex * 16;

  SigFox.begin();
  SigFox.beginPacket();
  SigFox.write(values, 9);
  SigFox.endPacket();
  SigFox.end();
}

float readTurbidity() {
  int sensorValue = 0;
  unsigned long int avgValue;
  float b;
  int buf[10], temp;
  for (int i = 0; i < 10; i++)
  {
    buf[i] = analogRead(turbidityPin);
    delay(30);
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
    delay(30);
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

void tryReplaceExtremeValue(float value, float normalValue, float *extremeMeasurement,int *measurementIndex, int index){
  if (abs(value - normalValue) > abs(*extremeMeasurement - normalValue)) {
      *extremeMeasurement = value;
      *measurementIndex = index;
  }
}
