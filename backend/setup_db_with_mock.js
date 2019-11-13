﻿var db = connect('127.0.0.1:27017/waterProbeData');

db.createCollection('Probe');
db.createCollection('Location');
db.createCollection('Sensor');
db.createCollection('ObservedProperty');
db.createCollection('Turbidity_1D95A5');
db.createCollection('Temperature_1D95A5');

    
db.Probe.insert({_id : '1D95A5', description : 'Lorem ipsum dol', properties : {}, locations: [{locationReference: "123bc", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "Turbidity", description: "Water Turbidity"},{refToSensor: "Temperature", description: "Water Temperatur"}]});
db.Probe.insert({_id : '1D95A6', description : 'Lorem ipsum dol', properties : {}, locations: [{locationReference: "123bD", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "Turbidity", description: "Water Turbidity"},{refToSensor: "Temperature", description: "Water Temperatur"}]});
db.Location.insert({_id: "123bc", description : 'Lorem ipsum dolo', encodingType: "Some encodingType", location: {alt: 57.045249, long: 9.862715}});
db.Location.insert({_id: "123bD", description : 'Lorem ipsum dolo', encodingType: "Some encodingType", location: {alt:  57.049249, long: 9.863515}});
db.Sensor.insert({_id : 'Turbidity', description : 'Lorem ipsum dolor sit ame', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "NTU", observedPropertyRef:"WaterTurbidity"});
db.Sensor.insert({_id : 'Temperature', description : 'Lorem ipsum dolor sit ame', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "°C", observedPropertyRef:"WaterTemperature"});
db.ObservedProperty.insert({_id: "WaterTemperature", definition: "some URI", description: "The temperature of water"});
db.ObservedProperty.insert({_id: "WaterTurbidity", definition: "some URI", description: "The turbidity of water"});

db.Temperature_1D95A5.insert({phenomenonTime: "2014-12-31T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "12"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-01T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "13"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-02T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "14"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-03T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "15"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-04T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "16"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-05T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "17"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-06T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "18"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-07T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "19"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-08T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "20"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-09T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "21"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-10T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "22"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-11T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "23"});
db.Temperature_1D95A5.insert({phenomenonTime: "2014-13-12T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "24"});

db.Turbidity_1D95A5.insert({phenomenonTime: "2014-12-31T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "300"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-01T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "310"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-02T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "320"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-03T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "330"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-04T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "340"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-05T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "350"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-06T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "360"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-07T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "370"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-08T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "380"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-09T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "390"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-10T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "400"})
db.Turbidity_1D95A5.insert({phenomenonTime: "2014-13-11T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "410"})


db.Temperature_1D95A6.insert({phenomenonTime: "2014-12-31T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "9"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-01T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "1"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-02T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "14"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-03T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-04T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "36"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-05T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "7"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-06T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "8"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-07T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "29"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-08T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-09T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "26"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-10T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "27"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-11T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "25"});
db.Temperature_1D95A6.insert({phenomenonTime: "2014-13-12T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "26"});

db.Turbidity_1D95A6.insert({phenomenonTime: "2014-12-31T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-01T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-02T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "20"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-03T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "30"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-04T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "40"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-05T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "50"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-06T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "60"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-07T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "70"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-08T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "80"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-09T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "90"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-10T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "00"})
db.Turbidity_1D95A6.insert({phenomenonTime: "2014-13-11T11:59:59.00+08:00", resultTime: "2014-12-31T11:59:59.00+08:00", result: "10"})