/*
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
using MongoDB.Bson;

namespace Org.OpenAPITools.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class DataStream : IEquatable<DataStream>
    {

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [BsonId]
        [Required]
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [BsonElement("description")]
        [Required]
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ObservationType
        /// </summary>
        [BsonElement("observationType")]
        [Required]
        [DataMember(Name="observationtype", EmitDefaultValue=false)]
        public Object ObservationType { get; set; }

        /// <summary>
        /// Gets or Sets UnitOfMeasurement
        /// </summary>
        [BsonElement("unitOfMeasurement")]
        [Required]
        [DataMember(Name="unitofMeasurement", EmitDefaultValue=false)]
        public List<Object> UnitOfMeasurement { get; set; }

        /// <summary>
        /// Gets or Sets ObservedArea
        /// </summary>
        [BsonElement("observedArea")]
        [DataMember(Name="observedarea", EmitDefaultValue=false)]
        public Object ObservedArea { get; set; }

        /// <summary>
        /// Gets or Sets PhenomenonTime
        /// </summary>
        [BsonElement("phenomenonTime")]
        [DataMember(Name="phenomenontime", EmitDefaultValue=false)]
        public Object PhenomenonTime { get; set; }

        /// <summary>
        /// Gets or Sets ResultTime
        /// </summary>
        [BsonElement("resultTime")]
        [DataMember(Name="resulttime", EmitDefaultValue=false)]
        public Object ResultTime { get; set; }

        /// <summary>
        /// Gets or Sets ThingRef
        /// </summary>
        [BsonElement("thingRef")]
        [Required]
        [DataMember(Name="thingref", EmitDefaultValue=false)]
        public string ThingRef { get; set; }

        /// <summary>
        /// Gets or Sets SensorRef
        /// </summary>
        [BsonElement("sensorRef")]
        [Required]
        [DataMember(Name="sensorref", EmitDefaultValue=false)]
        public string SensorRef { get; set; }

        /// <summary>
        /// Gets or Sets ObservedPropertyRef
        /// </summary>
        [BsonElement("observedPropertyRef")]
        [Required]
        [DataMember(Name="observedpropertyref", EmitDefaultValue=false)]
        public string ObservedPropertyRef { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DataStream {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ObservationType: ").Append(ObservationType).Append("\n");
            sb.Append("  UnitOfMeasurement: ").Append(UnitOfMeasurement).Append("\n");
            sb.Append("  ObservedArea: ").Append(ObservedArea).Append("\n");
            sb.Append("  PhenomenonTime: ").Append(PhenomenonTime).Append("\n");
            sb.Append("  ResultTime: ").Append(ResultTime).Append("\n");
            sb.Append("  ThingRef: ").Append(ThingRef).Append("\n");
            sb.Append("  SensorRef: ").Append(SensorRef).Append("\n");
            sb.Append("  ObservedPropertyRef: ").Append(ObservedPropertyRef).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DataStream)obj);
        }

        /// <summary>
        /// Returns true if DataStream instances are equal
        /// </summary>
        /// <param name="other">Instance of DataStream to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataStream other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) && 
                (
                    ObservationType == other.ObservationType ||
                    ObservationType != null &&
                    ObservationType.Equals(other.ObservationType)
                ) && 
                (
                    UnitOfMeasurement == other.UnitOfMeasurement ||
                    UnitOfMeasurement != null &&
                    other.UnitOfMeasurement != null &&
                    UnitOfMeasurement.SequenceEqual(other.UnitOfMeasurement)
                ) && 
                (
                    ObservedArea == other.ObservedArea ||
                    ObservedArea != null &&
                    ObservedArea.Equals(other.ObservedArea)
                ) && 
                (
                    PhenomenonTime == other.PhenomenonTime ||
                    PhenomenonTime != null &&
                    PhenomenonTime.Equals(other.PhenomenonTime)
                ) && 
                (
                    ResultTime == other.ResultTime ||
                    ResultTime != null &&
                    ResultTime.Equals(other.ResultTime)
                ) && 
                (
                    ThingRef == other.ThingRef ||
                    ThingRef != null &&
                    ThingRef.Equals(other.ThingRef)
                ) && 
                (
                    SensorRef == other.SensorRef ||
                    SensorRef != null &&
                    SensorRef.Equals(other.SensorRef)
                ) && 
                (
                    ObservedPropertyRef == other.ObservedPropertyRef ||
                    ObservedPropertyRef != null &&
                    ObservedPropertyRef.Equals(other.ObservedPropertyRef)
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
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (ObservationType != null)
                    hashCode = hashCode * 59 + ObservationType.GetHashCode();
                    if (UnitOfMeasurement != null)
                    hashCode = hashCode * 59 + UnitOfMeasurement.GetHashCode();
                    if (ObservedArea != null)
                    hashCode = hashCode * 59 + ObservedArea.GetHashCode();
                    if (PhenomenonTime != null)
                    hashCode = hashCode * 59 + PhenomenonTime.GetHashCode();
                    if (ResultTime != null)
                    hashCode = hashCode * 59 + ResultTime.GetHashCode();
                    if (ThingRef != null)
                    hashCode = hashCode * 59 + ThingRef.GetHashCode();
                    if (SensorRef != null)
                    hashCode = hashCode * 59 + SensorRef.GetHashCode();
                    if (ObservedPropertyRef != null)
                    hashCode = hashCode * 59 + ObservedPropertyRef.GetHashCode();
                return hashCode;
            }
        }

         

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(DataStream left, DataStream right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DataStream left, DataStream right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
