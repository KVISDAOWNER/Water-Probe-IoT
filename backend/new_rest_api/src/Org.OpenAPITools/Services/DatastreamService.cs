using MongoDB.Driver;
using Org.OpenAPITools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Services
{
    public class DatastreamService
    {
        private readonly IMongoCollection<DataStream> _dataStreams;

        public DatastreamService(IWaterProbeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dataStreams = database.GetCollection<DataStream>(settings.DatastreamsCollectionName);
        }

        public List<DataStream> Get() =>
            _dataStreams.Find(datastream => true).ToList();

        public DataStream Get(string id) =>
            _dataStreams.Find<DataStream>(dataStream => dataStream.Name == id).FirstOrDefault();


        public DataStream Create(DataStream dataStream)
        {
            _dataStreams.InsertOne(dataStream);
            return dataStream;
        }

        public void Update(string id, DataStream dataStreamIn) =>
            _dataStreams.ReplaceOne(dataStream => dataStream.Name == id, dataStreamIn);

        public void Remove(DataStream dataStreamIn) =>
            _dataStreams.DeleteOne(dataStream => dataStream.Name == dataStreamIn.Name);

        public void Remove(string id) =>
            _dataStreams.DeleteOne(dataStream => dataStream.Name == id);
    }
}
