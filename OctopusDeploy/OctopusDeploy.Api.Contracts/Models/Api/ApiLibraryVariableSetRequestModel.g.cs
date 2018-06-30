using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiLibraryVariableSetRequestModel : AbstractApiRequestModel
        {
                public ApiLibraryVariableSetRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string contentType,
                        string jSON,
                        string name,
                        string variableSetId)
                {
                        this.ContentType = contentType;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                private string contentType;

                [Required]
                public string ContentType
                {
                        get
                        {
                                return this.contentType;
                        }

                        set
                        {
                                this.contentType = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string variableSetId;

                public string VariableSetId
                {
                        get
                        {
                                return this.variableSetId;
                        }

                        set
                        {
                                this.variableSetId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>51ecf2b56c41a60555052b758e2d49cd</Hash>
</Codenesium>*/