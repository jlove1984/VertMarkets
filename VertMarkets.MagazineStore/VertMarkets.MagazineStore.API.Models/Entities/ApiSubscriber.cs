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
    /// ApiSubscriber
    /// </summary>
    [DataContract]
    public partial class ApiSubscriber : IEquatable<ApiSubscriber>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiSubscriber" /> class.
        /// </summary>
        /// <param name="id">Subscriber Identifier to be used in the Answer Endpoint..</param>
        /// <param name="firstName">firstName.</param>
        /// <param name="lastName">lastName.</param>
        /// <param name="magazineIds">The Id&#x27;s of the magazines that this user is subscribed to..</param>
        public ApiSubscriber(Guid? id = default(Guid?), string firstName = default(string), string lastName = default(string), List<int?> magazineIds = default(List<int?>))
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MagazineIds = magazineIds;
        }
        /// <summary>
        /// Subscriber Identifier to be used in the Answer Endpoint.
        /// </summary>
        /// <value>Subscriber Identifier to be used in the Answer Endpoint.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }
        /// <summary>
        /// The Id&#x27;s of the magazines that this user is subscribed to.
        /// </summary>
        /// <value>The Id&#x27;s of the magazines that this user is subscribed to.</value>
        [DataMember(Name = "magazineIds", EmitDefaultValue = false)]
        public List<int?> MagazineIds { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiSubscriber {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  MagazineIds: ").Append(MagazineIds).Append("\n");
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
            return this.Equals(input as ApiSubscriber);
        }
        /// <summary>
        /// Returns true if ApiSubscriber instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiSubscriber to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiSubscriber input)
        {
            if (input == null)
                return false;
            return
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) &&
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) &&
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) &&
                (
                    this.MagazineIds == input.MagazineIds ||
                    this.MagazineIds != null &&
                    input.MagazineIds != null &&
                    this.MagazineIds.SequenceEqual(input.MagazineIds)
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.MagazineIds != null)
                    hashCode = hashCode * 59 + this.MagazineIds.GetHashCode();
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
