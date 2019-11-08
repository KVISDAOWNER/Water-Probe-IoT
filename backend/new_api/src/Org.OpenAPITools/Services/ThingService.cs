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
        readonly IMongoCollection<Location> _locations;


        public ThingService(IMongoDBSettings settings)
        {
            var client = new MongoClient("mongodb://" + settings.Host + ":" + settings.Port);
            mongoDatabase = client.GetDatabase(settings.Database);
            _probes = mongoDatabase.GetCollection<Probe>("Probe");
            _locations = mongoDatabase.GetCollection<Location>("Location");
        }

        public List<Probe> GetProbes() =>
            _probes.Find(probe => true).ToList();

        public Probe GetProbe(string id) =>
            _probes.Find<Probe>(p => p.Id == id).FirstOrDefault();

        public List<Location> getLocations() =>
            _locations.Find(location => true).ToList();

        public Location GetLocation(string id) =>
            _locations.Find(location => location.Id == id).FirstOrDefault();
    }
}