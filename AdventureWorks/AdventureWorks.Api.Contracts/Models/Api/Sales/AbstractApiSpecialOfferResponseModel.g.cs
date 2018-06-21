using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string category,
                        string description,
                        decimal discountPct,
                        DateTime endDate,
                        Nullable<int> maxQty,
                        int minQty,
                        DateTime modifiedDate,
                        Guid rowguid,
                        int specialOfferID,
                        DateTime startDate,
                        string type)
                {
                        this.Category = category;
                        this.Description = description;
                        this.DiscountPct = discountPct;
                        this.EndDate = endDate;
                        this.MaxQty = maxQty;
                        this.MinQty = minQty;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SpecialOfferID = specialOfferID;
                        this.StartDate = startDate;
                        this.Type = type;
                }

                public string Category { get; private set; }

                public string Description { get; private set; }

                public decimal DiscountPct { get; private set; }

                public DateTime EndDate { get; private set; }

                public Nullable<int> MaxQty { get; private set; }

                public int MinQty { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SpecialOfferID { get; private set; }

                public DateTime StartDate { get; private set; }

                public string Type { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCategoryValue { get; set; } = true;

                public bool ShouldSerializeCategory()
                {
                        return this.ShouldSerializeCategoryValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDiscountPctValue { get; set; } = true;

                public bool ShouldSerializeDiscountPct()
                {
                        return this.ShouldSerializeDiscountPctValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEndDateValue { get; set; } = true;

                public bool ShouldSerializeEndDate()
                {
                        return this.ShouldSerializeEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMaxQtyValue { get; set; } = true;

                public bool ShouldSerializeMaxQty()
                {
                        return this.ShouldSerializeMaxQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMinQtyValue { get; set; } = true;

                public bool ShouldSerializeMinQty()
                {
                        return this.ShouldSerializeMinQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

                public bool ShouldSerializeSpecialOfferID()
                {
                        return this.ShouldSerializeSpecialOfferIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTypeValue { get; set; } = true;

                public bool ShouldSerializeType()
                {
                        return this.ShouldSerializeTypeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCategoryValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeDiscountPctValue = false;
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeMaxQtyValue = false;
                        this.ShouldSerializeMinQtyValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSpecialOfferIDValue = false;
                        this.ShouldSerializeStartDateValue = false;
                        this.ShouldSerializeTypeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>783608c5b05f27074d2d851d4d59d195</Hash>
</Codenesium>*/