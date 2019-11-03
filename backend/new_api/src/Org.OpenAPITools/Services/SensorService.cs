using MongoDB.Driver;
using Org.OpenAPITools.Models;
using Org.OpenAPITools.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Services
{
    public class SensorService
    {
        private readonly IMongoCollection<DBSensor> _sensors;
        private readonly IMongoDatabase mongoDatabase;
        private readonly ThingService thingService;

        public SensorService(IWaterProbeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            mongoDatabase = client.GetDatabase(settings.DatabaseName);
            _sensors = mongoDatabase.GetCollection<DBSensor>("Sensors");
        }

        public DBSensor GetSensor(string sensorId)
        {
            var sensors = _sensors.Find(s => true);
            return _sensors.Find<DBSensor>(s => s.Id == sensorId).FirstOrDefault();
        }
    }
}
