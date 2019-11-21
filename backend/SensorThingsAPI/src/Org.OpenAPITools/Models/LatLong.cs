﻿/*
 * WaterProbe API
 *
 * API for waterprobing
 *
 * The version of the OpenAPI document: 1
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Org.OpenAPITools.Converters;
using MongoDB.Bson.Serialization.Attributes;

namespace Org.OpenAPITools.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class LatLong : IEquatable<LatLong>
    {
        /// <summary>
        /// Gets or Sets Lat
        /// </summary>
        [BsonElement("lat")]
        [DataMember(Name = "lat", EmitDefaultValue = false)]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Long
        /// </summary>
        [BsonElement("long")]
        [DataMember(Name = "long", EmitDefaultValue = false)]
        public double Longitude { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LatLong {\n");
            sb.Append("  Lat: ").Append(Latitude).Append("\n");
            sb.Append("  Long: ").Append(Longitude).Append("\n");
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
            return obj.GetType() == GetType() && Equals((LatLong)obj);
        }

        /// <summary>
        /// Returns true if LatLong instances are equal
        /// </summary>
        /// <param name="other">Instance of LatLong to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LatLong other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Latitude == other.Latitude ||
                    Latitude != null &&
                    Latitude.Equals(other.Latitude)
                ) &&
                (
                    Longitude == other.Longitude ||
                    Longitude != null &&
                    Longitude.Equals(other.Longitude)
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
                if (Latitude != null)
                    hashCode = hashCode * 59 + Latitude.GetHashCode();
                if (Longitude != null)
                    hashCode = hashCode * 59 + Longitude.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(LatLong left, LatLong right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LatLong left, LatLong right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
