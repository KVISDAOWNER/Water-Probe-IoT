using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class Prediction
    {
        [Required]
        [DataMember(Name = "probe", EmitDefaultValue = false)]
        public string Probe { get; set; }

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [Required]
        [DataMember(Name = "sensor", EmitDefaultValue = false)]
        public string Sensor { get; set; }

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [BsonElement("phenomenonTime")]
        [Required]
        [DataMember(Name = "phenomenonTime", EmitDefaultValue = false)]
        public string PhenomenonTime { get; set; }

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [BsonElement("resultTime")]
        [Required]
        [DataMember(Name = "resultTime", EmitDefaultValue = false)]
        public string ResultTime { get; set; }

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [BsonElement("result")]
        [Required]
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public double Result { get; set; }
     
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
    }
}
