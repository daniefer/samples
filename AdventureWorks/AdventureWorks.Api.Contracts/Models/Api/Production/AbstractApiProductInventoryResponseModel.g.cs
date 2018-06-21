using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductInventoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int bin,
                        short locationID,
                        DateTime modifiedDate,
                        int productID,
                        short quantity,
                        Guid rowguid,
                        string shelf)
                {
                        this.Bin = bin;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.Rowguid = rowguid;
                        this.Shelf = shelf;
                }

                public int Bin { get; private set; }

                public short LocationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public short Quantity { get; private set; }

                public Guid Rowguid { get; private set; }

                public string Shelf { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBinValue { get; set; } = true;

                public bool ShouldSerializeBin()
                {
                        return this.ShouldSerializeBinValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLocationIDValue { get; set; } = true;

                public bool ShouldSerializeLocationID()
                {
                        return this.ShouldSerializeLocationIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeQuantityValue { get; set; } = true;

                public bool ShouldSerializeQuantity()
                {
                        return this.ShouldSerializeQuantityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShelfValue { get; set; } = true;

                public bool ShouldSerializeShelf()
                {
                        return this.ShouldSerializeShelfValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBinValue = false;
                        this.ShouldSerializeLocationIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeQuantityValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeShelfValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b39c8562305e5ed812e186a321c16e64</Hash>
</Codenesium>*/