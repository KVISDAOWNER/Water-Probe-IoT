using MongoDB.Driver;
using Org.OpenAPITools.Models;
using System.Collections.Generic;
using System.Linq;

namespace Org.OpenAPITools.Services
{
    public class ThingService
    {
        private readonly IMongoCollection<Thing> _things;

        public ThingService(IThingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _things = database.GetCollection<Thing>(settings.ThingCollectionName);
        }

        public List<Thing> Get() =>
            _things.Find(thing => true).ToList();

        public Thing Get(string name) =>
            _things.Find<Thing>(thing => thing.Name == name).FirstOrDefault();

        public Thing Create(Thing thing)
        {
            _things.InsertOne(thing);
            return thing;
        }
    }
}