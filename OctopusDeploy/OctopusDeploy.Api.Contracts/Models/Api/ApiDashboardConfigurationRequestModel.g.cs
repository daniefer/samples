using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDashboardConfigurationRequestModel : AbstractApiRequestModel
        {
                public ApiDashboardConfigurationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string includedEnvironmentIds,
                        string includedProjectIds,
                        string includedTenantIds,
                        string includedTenantTags,
                        string jSON)
                {
                        this.IncludedEnvironmentIds = includedEnvironmentIds;
                        this.IncludedProjectIds = includedProjectIds;
                        this.IncludedTenantIds = includedTenantIds;
                        this.IncludedTenantTags = includedTenantTags;
                        this.JSON = jSON;
                }

                private string includedEnvironmentIds;

                [Required]
                public string IncludedEnvironmentIds
                {
                        get
                        {
                                return this.includedEnvironmentIds;
                        }

                        set
                        {
                                this.includedEnvironmentIds = value;
                        }
                }

                private string includedProjectIds;

                [Required]
                public string IncludedProjectIds
                {
                        get
                        {
                                return this.includedProjectIds;
                        }

                        set
                        {
                                this.includedProjectIds = value;
                        }
                }

                private string includedTenantIds;

                public string IncludedTenantIds
                {
                        get
                        {
                                return this.includedTenantIds;
                        }

                        set
                        {
                                this.includedTenantIds = value;
                        }
                }

                private string includedTenantTags;

                public string IncludedTenantTags
                {
                        get
                        {
                                return this.includedTenantTags;
                        }

                        set
                        {
                                this.includedTenantTags = value;
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
        }
}

/*<Codenesium>
    <Hash>b738237d0174d91421aee77b9603175f</Hash>
</Codenesium>*/