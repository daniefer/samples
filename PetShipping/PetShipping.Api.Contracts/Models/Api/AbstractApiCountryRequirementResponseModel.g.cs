using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiCountryRequirementResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int countryId,
                        string details,
                        int id)
                {
                        this.CountryId = countryId;
                        this.Details = details;
                        this.Id = id;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                public int CountryId { get; private set; }

                public string CountryIdEntity { get; set; }

                public string Details { get; private set; }

                public int Id { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryIdValue { get; set; } = true;

                public bool ShouldSerializeCountryId()
                {
                        return this.ShouldSerializeCountryIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDetailsValue { get; set; } = true;

                public bool ShouldSerializeDetails()
                {
                        return this.ShouldSerializeDetailsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryIdValue = false;
                        this.ShouldSerializeDetailsValue = false;
                        this.ShouldSerializeIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c39c86d8608d3c94832f0626021fd435</Hash>
</Codenesium>*/