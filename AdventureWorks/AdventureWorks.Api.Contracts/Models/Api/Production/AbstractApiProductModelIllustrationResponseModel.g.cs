using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelIllustrationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int illustrationID,
                        DateTime modifiedDate,
                        int productModelID)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductModelID = productModelID;
                }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductModelID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

                public bool ShouldSerializeIllustrationID()
                {
                        return this.ShouldSerializeIllustrationIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelIDValue { get; set; } = true;

                public bool ShouldSerializeProductModelID()
                {
                        return this.ShouldSerializeProductModelIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIllustrationIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductModelIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>50b52dd4d3f4a90c266c61b300aaf756</Hash>
</Codenesium>*/