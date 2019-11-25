using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorThingsAPI.Models.DBModels
{
    public class DBSensor : Sensor
    {
        [BsonElement("unitOfMeasurement")]
        public string UnitOfMeasurement { get; set; }

        [BsonElement("observedPropertyRef")]
        public string ObservedPropertyRef { get; set; }
    }
}
