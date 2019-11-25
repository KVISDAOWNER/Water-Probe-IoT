﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Sensor : IEquatable<Sensor>
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [BsonId]
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [BsonElement("description")]
        [Required]
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets EncodingType
        /// </summary>
        [BsonElement("encodingType")]
        [Required]
        [DataMember(Name = "encodingType", EmitDefaultValue = false)]
        public Object EncodingType { get; set; }

        /// <summary>
        /// Gets or Sets MetaData
        /// </summary>
        [BsonElement("metadata")]
        [Required]
        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public Object Metadata { get; set; }

        [BsonElement("observedPropertyRef")]
        [Required]
        [DataMember(Name = "observedPropertyRef")]
        public string ObservedPropertyRef { get; set; }

        [BsonElement("unitOfMeasurement")]
        [Required]
        [DataMember(Name = "unitOfMeasurement")]
        public string unitOfMeasurement { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Sensor {\n");
            sb.Append("  Name: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EncodingType: ").Append(EncodingType).Append("\n");
            sb.Append("  MetaData: ").Append(Metadata).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Sensor)obj);
        }

        /// <summary>
        /// Returns true if Sensor instances are equal
        /// </summary>
        /// <param name="other">Instance of Sensor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Sensor other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    EncodingType == other.EncodingType ||
                    EncodingType != null &&
                    EncodingType.Equals(other.EncodingType)
                ) &&
                (
                    Metadata == other.Metadata ||
                    Metadata != null &&
                    Metadata.Equals(other.Metadata)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (EncodingType != null)
                    hashCode = hashCode * 59 + EncodingType.GetHashCode();
                if (Metadata != null)
                    hashCode = hashCode * 59 + Metadata.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Sensor left, Sensor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Sensor left, Sensor right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
