using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStudentXFamilyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int familyId,
                        int id,
                        int studentId)
                {
                        this.FamilyId = familyId;
                        this.Id = id;
                        this.StudentId = studentId;

                        this.FamilyIdEntity = nameof(ApiResponse.Families);
                        this.StudentIdEntity = nameof(ApiResponse.Students);
                }

                public int FamilyId { get; private set; }

                public string FamilyIdEntity { get; set; }

                public int Id { get; private set; }

                public int StudentId { get; private set; }

                public string StudentIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeFamilyIdValue { get; set; } = true;

                public bool ShouldSerializeFamilyId()
                {
                        return this.ShouldSerializeFamilyIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudentIdValue { get; set; } = true;

                public bool ShouldSerializeStudentId()
                {
                        return this.ShouldSerializeStudentIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeFamilyIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeStudentIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>71921b8bef6d0153a3c922b35d5df458</Hash>
</Codenesium>*/