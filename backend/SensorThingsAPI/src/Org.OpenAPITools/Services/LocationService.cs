using MongoDB.Driver;
using Org.OpenAPITools.Models;
using Org.OpenAPITools.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace Org.OpenAPITools.Services
{
    public class LocationService
    {
        private readonly IMongoDatabase mongoDatabase;
        readonly IMongoCollection<Location> _locations;


        public LocationService(IMongoDBSettings settings)
        {
            var client = new MongoClient("mongodb://" + settings.Host + ":" + settings.Port);
            mongoDatabase = client.GetDatabase(settings.Database);
            _locations = mongoDatabase.GetCollection<Location>("Location");

        }

        //The location related functionality is necessary to patch/get the location for a probe
        public void AddLocation(Location location)
        {
            _locations.InsertOne(location);
            return;
        }


        public List<Location> GetLocations() =>
            _locations.Find(location => true).ToList();

        public Location GetLocation(string id) =>
            _locations.Find(location => location.Id == id).FirstOrDefault();
    }
}