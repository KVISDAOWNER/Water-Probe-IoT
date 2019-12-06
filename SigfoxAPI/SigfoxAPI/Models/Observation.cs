using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Org.OpenAPITools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    /// <summary>
    /// This is the class we use for setting into the database.
    /// </summary>
    public class Observation
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }

        [BsonElement("phenomenonTime")]
        [Required]
        [DataMember(Name = "phenomenonTime", EmitDefaultValue = false)]
        public string PhenomenonTime { get; set; }

        [BsonElement("resultTime")]
        [Required]
        [DataMember(Name = "resultTime", EmitDefaultValue = false)]
        public string ResultTime { get; set; }

        [BsonElement("result")]
        [Required]
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public string Result { get; set; }

        public Observation(string phenomenonTime, string resultTime, string result)
        {
            this.PhenomenonTime = phenomenonTime;
            this.ResultTime = resultTime;
            this.Result = result;
        }
    }
}
