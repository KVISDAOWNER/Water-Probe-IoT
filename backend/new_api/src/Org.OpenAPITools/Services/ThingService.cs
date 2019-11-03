using MongoDB.Driver;
using Org.OpenAPITools.Models;
using Org.OpenAPITools.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace Org.OpenAPITools.Services
{
    public class ThingService
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<Probe> _probes;

        public ThingService(IWaterProbeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            mongoDatabase = client.GetDatabase(settings.DatabaseName);
            _probes = mongoDatabase.GetCollection<Probe>("Probes");
        }

        public List<Probe> GetProbes() =>
            _probes.Find(probe => true).ToList();

        public Probe GetProbe(string id) =>
            _probes.Find<Probe>(p => p.Id == id).FirstOrDefault();

        public List<Data> GetData(string collectionName) =>
            mongoDatabase.GetCollection<Data>(collectionName).Find(data => true).ToList();

        //public Thing Create(Thing thing)
        //{
        //    _things.InsertOne(thing);
        //    return thing;
        //}
    }
}