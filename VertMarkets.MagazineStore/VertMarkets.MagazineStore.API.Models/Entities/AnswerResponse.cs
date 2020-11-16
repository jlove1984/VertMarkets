﻿/* 
 * Vertmarkets Inc. Magazine Store
 *
 * API endpoints to work with magazine data
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
namespace VertMarkets.MagazineStore.API.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// AnswerResponse
    /// </summary>
    [DataContract]
    public partial class AnswerResponse : IEquatable<AnswerResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerResponse" /> class.
        /// </summary>
        /// <param name="totalTime">totalTime.</param>
        /// <param name="answerCorrect">answerCorrect.</param>
        /// <param name="shouldBe">shouldBe.</param>
        public AnswerResponse(string totalTime = default(string), bool? answerCorrect = default(bool?), List<Guid?> shouldBe = default(List<Guid?>))
        {
            this.TotalTime = totalTime;
            this.AnswerCorrect = answerCorrect;
            this.ShouldBe = shouldBe;
        }
        /// <summary>
        /// Gets or Sets TotalTime
        /// </summary>
        [DataMember(Name = "totalTime", EmitDefaultValue = false)]
        public string TotalTime { get; set; }
        /// <summary>
        /// Gets or Sets AnswerCorrect
        /// </summary>
        [DataMember(Name = "answerCorrect", EmitDefaultValue = false)]
        public bool? AnswerCorrect { get; set; }
        /// <summary>
        /// Gets or Sets ShouldBe
        /// </summary>
        [DataMember(Name = "shouldBe", EmitDefaultValue = false)]
        public List<Guid?> ShouldBe { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AnswerResponse {\n");
            sb.Append("  TotalTime: ").Append(TotalTime).Append("\n");
            sb.Append("  AnswerCorrect: ").Append(AnswerCorrect).Append("\n");
            sb.Append("  ShouldBe: ").Append(ShouldBe).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AnswerResponse);
        }
        /// <summary>
        /// Returns true if AnswerResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AnswerResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AnswerResponse input)
        {
            if (input == null)
                return false;
            return
                (
                    this.TotalTime == input.TotalTime ||
                    (this.TotalTime != null &&
                    this.TotalTime.Equals(input.TotalTime))
                ) &&
                (
                    this.AnswerCorrect == input.AnswerCorrect ||
                    (this.AnswerCorrect != null &&
                    this.AnswerCorrect.Equals(input.AnswerCorrect))
                ) &&
                (
                    this.ShouldBe == input.ShouldBe ||
                    this.ShouldBe != null &&
                    input.ShouldBe != null &&
                    this.ShouldBe.SequenceEqual(input.ShouldBe)
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
                int hashCode = 41;
                if (this.TotalTime != null)
                    hashCode = hashCode * 59 + this.TotalTime.GetHashCode();
                if (this.AnswerCorrect != null)
                    hashCode = hashCode * 59 + this.AnswerCorrect.GetHashCode();
                if (this.ShouldBe != null)
                    hashCode = hashCode * 59 + this.ShouldBe.GetHashCode();
                return hashCode;
            }
        }
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}



