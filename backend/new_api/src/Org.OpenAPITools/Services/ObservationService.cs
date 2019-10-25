using MongoDB.Driver;
using Org.OpenAPITools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Services
{
    public class ObservationService
    {
        private readonly IMongoCollection<Observation> _observation;

        public ObservationService(IWaterProbeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _observation = database.GetCollection<Observation>(settings.ObservationCollectionName);
        }

        public List<Observation> Get() =>
            _observation.Find(datastream => true).ToList();

      /*  public Observation Get(string id) =>
            _observation.Find<Observation>(observation => observation.id == id).FirstOrDefault();*/


        public List<Observation> GetDatastreamsObservations(string datastreamRef)
        {

            var col = _observation.CollectionNamespace.CollectionName;
            return _observation.Find<Observation>(observation => observation.DatastreamRef == datastreamRef).ToList();
        }

        public Observation Create(Observation observation)
        {
            _observation.InsertOne(observation);
            return observation;
        }

      /*  public void Update(string id, DataStream observationIn) =>
            _observation.ReplaceOne(observation => observation.Name == id, observationIn);

        public void Remove(DataStream observationIn) =>
            _observation.DeleteOne(observation => observation.Name == dataStreamIn.Name);

        public void Remove(string id) =>
            _observation.DeleteOne(dataStream => dataStream.Name == id);*/
    }

}

