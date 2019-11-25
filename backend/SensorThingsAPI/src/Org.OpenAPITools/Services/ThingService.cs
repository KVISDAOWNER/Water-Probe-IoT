using MongoDB.Driver;
using SensorThingsAPI.Models;
using SensorThingsAPI.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace SensorThingsAPI.Services
{
    public class ThingService
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<Probe> _probes;
        readonly IMongoCollection<Location> _locations;
        private readonly LocationService _locationService;

        public ThingService(IMongoDBSettings settings)
        {

            var client = new MongoClient("mongodb://" + settings.Host + ":" + settings.Port);
            mongoDatabase = client.GetDatabase(settings.Database);
            _probes = mongoDatabase.GetCollection<Probe>("Probe");
            _locations = mongoDatabase.GetCollection<Location>("Location");
            _locationService = new LocationService(settings);
        }

        public List<Probe> GetProbes() =>
            _probes.Find(probe => true).ToList();

        public Probe GetProbe(string id) =>
            _probes.Find<Probe>(p => p.Id == id).FirstOrDefault();

        public void AddLocationRefToProbe(string probeRef, LocationRef locationRef)
        {
            var filter = Builders<Probe>.Filter.Eq(e => e.Id, probeRef);

            var update = Builders<Probe>.Update.Push<LocationRef>(e => e.Locations, locationRef);

            _probes.FindOneAndUpdate(filter, update);
        }

    }
}