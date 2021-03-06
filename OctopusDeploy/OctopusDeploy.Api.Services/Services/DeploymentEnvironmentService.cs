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
	public partial class DeploymentEnvironmentService : AbstractDeploymentEnvironmentService, IDeploymentEnvironmentService
	{
		public DeploymentEnvironmentService(
			ILogger<IDeploymentEnvironmentRepository> logger,
			IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
			IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
			IBOLDeploymentEnvironmentMapper boldeploymentEnvironmentMapper,
			IDALDeploymentEnvironmentMapper daldeploymentEnvironmentMapper
			)
			: base(logger,
			       deploymentEnvironmentRepository,
			       deploymentEnvironmentModelValidator,
			       boldeploymentEnvironmentMapper,
			       daldeploymentEnvironmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6169b6edcc4b9d5ff8e96c4cf23dfc36</Hash>
</Codenesium>*/