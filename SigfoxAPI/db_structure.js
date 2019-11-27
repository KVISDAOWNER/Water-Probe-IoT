var db = connect('127.0.0.1:27017/waterProbeData');

db.createCollection('Probes');
db.createCollection('Locations');
db.createCollection('Sensors');
db.createCollection('ObservedProperty');
db.createCollection('Turbidity1D95A5');
db.createCollection('Ph1D95A5');
db.createCollection('Temperature1D95A5');


db.Probes.insert({'_id' : '1D95A5', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}, Location: {}, AttachedSensors: {}});
db.Locations.insert({'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}, EncodingType: "Some encodingType", Location: 'Coordinates here'});
db.Sensors.insert({'_id' : 'ds18b20', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', EncodingType: "Some encodingType", Metadata: "some data", UnitOfMesaurement: "Some unit", ObservedPropertyRef:"Ref to unique name of ObservedProperty"});
db.ObservedProperty.insert({_id: "called", URI: "some URI", Description: "some description"});
db.Turbidity1D95A5.insert({'_id' : 'Bjarke\'s probe', 'description' : 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'properties' : {}});

