using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class DeploymentHistoryService : AbstractDeploymentHistoryService, IDeploymentHistoryService
        {
                public DeploymentHistoryService(
                        ILogger<IDeploymentHistoryRepository> logger,
                        IDeploymentHistoryRepository deploymentHistoryRepository,
                        IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
                        IBOLDeploymentHistoryMapper boldeploymentHistoryMapper,
                        IDALDeploymentHistoryMapper daldeploymentHistoryMapper
                        )
                        : base(logger,
                               deploymentHistoryRepository,
                               deploymentHistoryModelValidator,
                               boldeploymentHistoryMapper,
                               daldeploymentHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4577b566551f59df06c413420b3e52a4</Hash>
</Codenesium>*/