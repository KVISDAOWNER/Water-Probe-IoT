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
        /// <summary>
        /// Gets or sets Probe
        /// </summary>

        [Required]
        [DataMember(Name = "probe", EmitDefaultValue = false)]
        public string Probe { get; set; }

        /// <summary>
        /// Gets or sets Sensor
        /// </summary>
        [Required]
        [DataMember(Name = "sensor", EmitDefaultValue = false)]
        public string Sensor { get; set; }

        /// <summary>
        /// Gets or sets Values, a list of Observations
        /// </summary>

        [BsonElement("values")]
        [Required]
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<Observation> Values { get; set; }

    }
}
