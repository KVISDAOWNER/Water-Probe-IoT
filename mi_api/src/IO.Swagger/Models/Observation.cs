using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class Observation
    {
        
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
        public double Result { get; set; }

        public Observation(string phenomenonTime, string resultTime, double result)
        {
            PhenomenonTime = phenomenonTime;
            ResultTime = resultTime;
            Result = result;
        }
    }
}
