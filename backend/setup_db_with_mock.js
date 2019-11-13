var db = connect('127.0.0.1:27017/waterProbeData');

db.createCollection('Probe');
db.createCollection('Location');
db.createCollection('Sensor');
db.createCollection('ObservedProperty');
db.createCollection('MJKDZ_1D95A5');
db.createCollection('DS18B20_1D95A5');
db.createCollection('PH4502C_1D95A5');
db.createCollection('Nitrogen_1D95A5');
db.createCollection('Phosphorus_1D95A5');

    
db.Probe.insert({_id : '1D95A5', description : 'Lorem ipsum dol', properties : {}, locations: [{locationReference: "locRef", locationTime: "2014-12-31T11:59:59.00+08:00"}], attachedSensors: [{refToSensor: "MJKDZ", description: "Water Turbidity"},{refToSensor: "DS18B20", description: "Water Temperatur"},{refToSensor: "PH4502C", description: "Water pH"},{refToSensor: "Nitrogen", description: "Water Nitrogen"}, {refToSensor: "Phosphorus", description: "Water Phosphorus"}]});

db.Location.insert({description : 'Lorem ipsum dolo', 'properties' : {}, encodingType: "Some encodingType", location: 'Coordinates here'});

db.Sensor.insert({_id : 'MJKDZ', description : 'Turbidity Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "NTU", observedPropertyRef:"WaterTurbidity"});
db.Sensor.insert({_id : 'DS18B20', description : 'Temperature Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "°C", observedPropertyRef:"WaterTemperature"});
db.Sensor.insert({_id : 'PH4502C', description : 'pH Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "pH", observedPropertyRef:"WaterPH"});
db.Sensor.insert({_id : 'Nitrogen', description : 'Nitrogen Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "mg/L", observedPropertyRef:"WaterNitrogen"});
db.Sensor.insert({_id : 'Phosphorus', description : 'Phosphorus Sensor', encodingType: "Some encodingType", metadata: {}, unitOfMeasurement: "mg/L", observedPropertyRef:"WaterPhosphorus"});

db.ObservedProperty.insert({_id: "WaterTemperature", definition: "some URI", description: "The temperature of water"});
db.ObservedProperty.insert({_id: "WaterTurbidity", definition: "some URI", description: "The turbidity of water"});
db.ObservedProperty.insert({_id: "WaterPH", definition: "some URI", description: "The pH of water"});
db.ObservedProperty.insert({_id: "WaterNitrogen", definition: "some URI", description: "The Nitrogen concentration of water"});
db.ObservedProperty.insert({_id: "WaterPhosphorus", definition: "some URI", description: "The Phosphorus concentration of water"});
