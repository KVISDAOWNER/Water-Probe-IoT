using MongoDB.Driver;
using SensorThingsAPI.Models;
using SensorThingsAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorThingsAPI.Services
{
    public class SensorService
    {
        private readonly IMongoCollection<DBSensor> _sensors;
        private readonly IMongoDatabase mongoDatabase;
        private readonly ThingService thingService;

        public SensorService(IMongoDBSettings settings)
        {
            var client = new MongoClient("mongodb://" + settings.Host + ':' + settings.Port);
            mongoDatabase = client.GetDatabase(settings.Database);
            _sensors = mongoDatabase.GetCollection<DBSensor>("Sensor");
        }

        public DBSensor GetSensor(string sensorId)
        {
            var sensors = _sensors.Find(s => true);
            return _sensors.Find<DBSensor>(s => s.Id == sensorId).FirstOrDefault();
        }
    }
}
