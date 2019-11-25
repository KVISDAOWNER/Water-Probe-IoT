using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorThingsAPI.Models.DBModels
{
    public class AttachedSensor
    {
        [BsonElement("refToSensor")]
        public string RefToSensor { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

    }
}
