using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    /// <summary>
    /// The prediction class is used as a schema for what values should be specified when posting machine predicted values
    /// </summary>
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


        [BsonElement("values")]
        [Required]
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<Observation> Values { get; set; }

     
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
    }
}
