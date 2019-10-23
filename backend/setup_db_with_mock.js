var db = connect('127.0.0.1:27017/waterProbeData');

db.createCollection('Thing');
db.createCollection('Location');
db.createCollection('HistoricalLocation');
db.createCollection('Sensor');
db.createCollection('ObservedProperty');
db.createCollection('Datastream');
db.createCollection('Observation');
db.createCollection('FeatureOfInterest');
db.createCollection('ValueCode');

db.Thing.insert({'_id' : 'Probe4', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}});
db.Thing.insert({'_id' : '87416', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}});
db.Thing.insert({'_id' : 'Østerå_probe', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}});
db.Thing.insert({'_id' : 'Bjarke\'s probe', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}});

 
db.Sensor.insert({'_id' : 'Sensor145', 'description' : 'consectetur adipiscing elit, sed do eiusmod tempor', 'encodingType' : 'ph', 'metadata': 'precision 1.1'})
db.Sensor.insert({'_id' : 'PHsensor1.0Turbo', 'description' : 'consectetur adipiscing elit, sed do eiusmod tempor', 'encodingType' : 'ph'})

db.ObservedProperty.insert({'_id' : 'DewPoint Temperature', 'definition' : 'http://examples.com#DewPointTemperature' , 'description' :'The dewpoint temperature is the temperature to which the air must be cooled, at constant pressure, for dew to form. As the grass and other objects near the ground cool to the dewpoint, some of the water vapor in the atmosphere condenses into liquid water on the objects.'})
db.ObservedProperty.insert({'_id' : 'ph', 'definition' : 'http://examples.com#p' , 'description' :'The dewpoint temperature is the temperature to which the air must be cooled, at constant pressure, for dew to form. As the grass and other objects near the ground cool to the dewpoint, some of the water vapor in the atmosphere condenses into liquid water on the objects.'})

db.ValueCode.insert({'_id' : '[ph]', 'value' : 'pH'})

db.Datastream.insert({'_id' : 'Datastream1', 'description' : 'Lorem ipsum dolor', 'observationType' : '[ph]', 'unitOfMeasurement' : [{}],  'thingRef' : 'Probe4', 'sensorRef' : 'Sensor145', 'observedPropertyRef' : 'ph'})

db.Observation.insert({'phenomenonTime' : '2010-12-23T10:20:00.00-07:00', 'resultTime' : '2019-10-23T10:24:37+0100', 'result' : '1.23', 'dataStreamRef' : 'Datastream1'})
db.Observation.insert({'phenomenonTime' : '2010-12-23T10:20:00.00-07:00', 'resultTime' : '2019-10-23T10:24:37+0100', 'result' : '2.67', 'dataStreamRef' : 'Datastream1'})
db.Observation.insert({'phenomenonTime' : '2010-12-23T10:20:00.00-07:00', 'resultTime' : '2019-10-23T10:24:37+0100', 'result' : '10.23', 'dataStreamRef' : 'Datastream1'})
db.Observation.insert({'phenomenonTime' : '2010-12-23T10:20:00.00-07:00', 'resultTime' : '2019-10-23T10:24:37+0100', 'result' : '7', 'dataStreamRef' : 'Datastream1'})