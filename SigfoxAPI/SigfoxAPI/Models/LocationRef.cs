using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class LocationRef
    {
        /// <summary>
        /// Gets or Sets location reference
        /// </summary> 
        [BsonElement("locationReference")]
        public string LocationReference { get; set; }

        /// <summary>
        /// Gets or Sets timestamp for location
        /// </summary> 
        [BsonElement("locationTime")]
        public string LocationTime { get; set; }
    }
}