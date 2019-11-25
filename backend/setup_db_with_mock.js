﻿db = db.getSiblingDB('waterProbeData')

db.createCollection('Probe');
db.createCollection('Location');
db.createCollection('Sensor');
db.createCollection('ObservedProperty');
db.createCollection('MJKDZ_1D95A5');
db.createCollection('DS18B20_1D95A5');
db.createCollection('PH4502C_1D95A5');
db.createCollection('Nitrogen_1D95A5');
db.createCollection('Phosphorus_1D95A5');


    
db.Sensor.insert({_id : 'MJKDZ', description : 'Turbidity Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "NTU", observedPropertyRef:"WaterTurbidity"});
db.Sensor.insert({_id : 'DS18B20', description : 'Temperature Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "°C", observedPropertyRef:"WaterTemperature"});
db.Sensor.insert({_id : 'PH4502C', description : 'pH Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "pH", observedPropertyRef:"WaterPH"});
db.Sensor.insert({_id : 'Nitrogen', description : 'Nitrogen Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "mg/L", observedPropertyRef:"WaterNitrogen"});
db.Sensor.insert({_id : 'Phosphorus', description : 'Phosphorus Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "mg/L", observedPropertyRef:"WaterPhosphorus"});

db.Probe.insert({_id : '1D95A5', description : 'Test probe', properties : {}, locations: [{locationReference: "locRef", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "MJKDZ", description: "Water Turbidity"},{refToSensor: "DS18B20", description: "Water Temperatur"},{refToSensor: "PH4502C", description: "Water pH"},{refToSensor: "Nitrogen", description: "Water Nitrogen"}, {refToSensor: "Phosphorus", description: "Water Phosphorus"}]});
db.Probe.insert({_id : '1D95A7', description : 'Mock probe', properties : {}, locations: [{locationReference: "123bc", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "Turbidity", description: "Water Turbidity"},{refToSensor: "Temperature", description: "Water Temperatur"}]});
db.Probe.insert({_id : '1D95A6', description : 'Mock probe', properties : {}, locations: [{locationReference: "123bD", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "Turbidity", description: "Water Turbidity"},{refToSensor: "Temperature", description: "Water Temperatur"}]});
db.Location.insert({_id: "123bc", description : 'Lorem ipsum dolo', encodingType: "Some encodingType", location: {lat: 57.045249, long: 9.862715}});
db.Location.insert({_id: "123bD", description : 'Lorem ipsum dolo', encodingType: "Some encodingType", location: {lat:  57.049249, long: 9.863515}});
db.Sensor.insert({_id : 'Turbidity', description : 'Lorem ipsum dolor sit ame', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "NTU", observedPropertyRef:"WaterTurbidity"});
db.Sensor.insert({_id : 'Temperature', description : 'Lorem ipsum dolor sit ame', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "°C", observedPropertyRef:"WaterTemperature"});
db.ObservedProperty.insert({_id: "WaterTemperature", definition: "some URI", description: "The temperature of water"});
db.ObservedProperty.insert({_id: "WaterTurbidity", definition: "some URI", description: "The turbidity of water"});

db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-01T11:59:59.00+08:00", resultTime: "2014-01-01T11:59:59.00+08:00", result: "12"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-02T11:59:59.00+08:00", resultTime: "2014-01-02T11:59:59.00+08:00", result: "13"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-03T11:59:59.00+08:00", resultTime: "2014-01-03T11:59:59.00+08:00", result: "14"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-04T11:59:59.00+08:00", resultTime: "2014-01-04T11:59:59.00+08:00", result: "15"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-05T11:59:59.00+08:00", resultTime: "2014-01-05T11:59:59.00+08:00", result: "16"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-06T11:59:59.00+08:00", resultTime: "2014-01-06T11:59:59.00+08:00", result: "17"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-07T11:59:59.00+08:00", resultTime: "2014-01-07T11:59:59.00+08:00", result: "18"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-08T11:59:59.00+08:00", resultTime: "2014-01-08T11:59:59.00+08:00", result: "19"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-09T11:59:59.00+08:00", resultTime: "2014-01-09T11:59:59.00+08:00", result: "20"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-10T11:59:59.00+08:00", resultTime: "2014-01-10T11:59:59.00+08:00", result: "21"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-11T11:59:59.00+08:00", resultTime: "2014-01-11T11:59:59.00+08:00", result: "22"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-12T11:59:59.00+08:00", resultTime: "2014-01-12T11:59:59.00+08:00", result: "23"});
db.Temperature_1D95A7.insert({phenomenonTime: "2014-01-13T11:59:59.00+08:00", resultTime: "2014-01-13T11:59:59.00+08:00", result: "24"});

db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-01T11:59:59.00+08:00", resultTime: "2014-01-01T11:59:59.00+08:00", result: "300"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-02T11:59:59.00+08:00", resultTime: "2014-01-02T11:59:59.00+08:00", result: "310"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-03T11:59:59.00+08:00", resultTime: "2014-01-03T11:59:59.00+08:00", result: "320"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-04T11:59:59.00+08:00", resultTime: "2014-01-04T11:59:59.00+08:00", result: "330"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-05T11:59:59.00+08:00", resultTime: "2014-01-05T11:59:59.00+08:00", result: "340"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-06T11:59:59.00+08:00", resultTime: "2014-01-06T11:59:59.00+08:00", result: "350"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-07T11:59:59.00+08:00", resultTime: "2014-01-07T11:59:59.00+08:00", result: "360"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-08T11:59:59.00+08:00", resultTime: "2014-01-08T11:59:59.00+08:00", result: "370"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-09T11:59:59.00+08:00", resultTime: "2014-01-09T11:59:59.00+08:00", result: "380"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-10T11:59:59.00+08:00", resultTime: "2014-01-10T11:59:59.00+08:00", result: "390"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-11T11:59:59.00+08:00", resultTime: "2014-01-11T11:59:59.00+08:00", result: "400"})
db.Turbidity_1D95A7.insert({phenomenonTime: "2014-01-12T11:59:59.00+08:00", resultTime: "2014-01-12T11:59:59.00+08:00", result: "410"})


db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-01T11:59:59.00+08:00", resultTime: "2014-01-01T11:59:59.00+08:00", result: "9"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-02T11:59:59.00+08:00", resultTime: "2014-01-02T11:59:59.00+08:00", result: "1"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-03T11:59:59.00+08:00", resultTime: "2014-01-03T11:59:59.00+08:00", result: "14"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-04T11:59:59.00+08:00", resultTime: "2014-01-04T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-05T11:59:59.00+08:00", resultTime: "2014-01-05T11:59:59.00+08:00", result: "36"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-06T11:59:59.00+08:00", resultTime: "2014-01-06T11:59:59.00+08:00", result: "7"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-07T11:59:59.00+08:00", resultTime: "2014-01-07T11:59:59.00+08:00", result: "8"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-08T11:59:59.00+08:00", resultTime: "2014-01-08T11:59:59.00+08:00", result: "29"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-09T11:59:59.00+08:00", resultTime: "2014-01-09T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-10T11:59:59.00+08:00", resultTime: "2014-01-10T11:59:59.00+08:00", result: "26"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-11T11:59:59.00+08:00", resultTime: "2014-01-11T11:59:59.00+08:00", result: "27"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-12T11:59:59.00+08:00", resultTime: "2014-01-12T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-01-13T11:59:59.00+08:00", resultTime: "2014-01-13T11:59:59.00+08:00", result: "26"});

db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-01T11:59:59.00+08:00", resultTime: "2014-01-01T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-02T11:59:59.00+08:00", resultTime: "2014-01-02T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-03T11:59:59.00+08:00", resultTime: "2014-01-03T11:59:59.00+08:00", result: "20"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-04T11:59:59.00+08:00", resultTime: "2014-01-04T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-05T11:59:59.00+08:00", resultTime: "2014-01-05T11:59:59.00+08:00", result: "40"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-06T11:59:59.00+08:00", resultTime: "2014-01-06T11:59:59.00+08:00", result: "50"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-07T11:59:59.00+08:00", resultTime: "2014-01-07T11:59:59.00+08:00", result: "60"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-08T11:59:59.00+08:00", resultTime: "2014-01-08T11:59:59.00+08:00", result: "70"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-09T11:59:59.00+08:00", resultTime: "2014-01-09T11:59:59.00+08:00", result: "80"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-10T11:59:59.00+08:00", resultTime: "2014-01-10T11:59:59.00+08:00", result: "90"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-11T11:59:59.00+08:00", resultTime: "2014-01-11T11:59:59.00+08:00", result: "01"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-01-12T11:59:59.00+08:00", resultTime: "2014-01-12T11:59:59.00+08:00", result: "10"})

db.ObservedProperty.insert({_id: "WaterPH", definition: "some URI", description: "The pH of water"});
db.ObservedProperty.insert({_id: "WaterNitrogen", definition: "some URI", description: "The Nitrogen concentration of water"});
db.ObservedProperty.insert({_id: "WaterPhosphorus", definition: "some URI", description: "The Phosphorus concentration of water"});
