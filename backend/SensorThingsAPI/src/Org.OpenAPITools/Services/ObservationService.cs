using MongoDB.Driver;
using SensorThingsAPI.Models;
using SensorThingsAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorThingsAPI.Services
{
    public class ObservationService
    {
        private readonly IMongoDatabase mongoDatabase;
        public ObservationService(IMongoDBSettings settings)
        {
            var client = new MongoClient("mongodb://" + settings.Host + ':' + settings.Port);
            mongoDatabase = client.GetDatabase(settings.Database);
        }


        public List<Observation> GetDatastreamsObservations(string datastreamRef)
        {
            var collection = mongoDatabase.GetCollection<Observation>(datastreamRef);
            var result = collection.Find<Observation>(d => true).ToList();
            return result;
        }
    }

}

