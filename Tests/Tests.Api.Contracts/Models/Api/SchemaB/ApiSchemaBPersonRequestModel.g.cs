using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiSchemaBPersonRequestModel : AbstractApiRequestModel
        {
                public ApiSchemaBPersonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name)
                {
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>59c96c4c37f6e29184d9298ddc55f8f2</Hash>
</Codenesium>*/