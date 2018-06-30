using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public partial class ActionTemplateService : AbstractActionTemplateService, IActionTemplateService
        {
                public ActionTemplateService(
                        ILogger<IActionTemplateRepository> logger,
                        IActionTemplateRepository actionTemplateRepository,
                        IApiActionTemplateRequestModelValidator actionTemplateModelValidator,
                        IBOLActionTemplateMapper bolactionTemplateMapper,
                        IDALActionTemplateMapper dalactionTemplateMapper
                        )
                        : base(logger,
                               actionTemplateRepository,
                               actionTemplateModelValidator,
                               bolactionTemplateMapper,
                               dalactionTemplateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>efc84e84f54ccaccc5a486cabe1cca12</Hash>
</Codenesium>*/