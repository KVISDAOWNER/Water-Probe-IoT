using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class Probe
    {
        [BsonId]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Descripton
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [BsonElement("properties")]
        public Object Properties { get; set; }


        /// <summary>
        /// Gets or Sets Locations
        /// </summary> 
        [BsonElement("locations")]
        public List<LocationRef> Locations { get; set; }

        /// <summary>
        /// Gets or Sets Attached Sensors
        /// </summary>
        [BsonElement("attachedSensors")]
        public List<AttachedSensor> AttachedSensors { get; set; }


        
    }
}
