using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/projectTriggers")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProjectTriggerController : AbstractProjectTriggerController
	{
		public ProjectTriggerController(
			ApiSettings settings,
			ILogger<ProjectTriggerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProjectTriggerService projectTriggerService,
			IApiProjectTriggerModelMapper projectTriggerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       projectTriggerService,
			       projectTriggerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e4a90802e58a011fe4cc707d16a30c5c</Hash>
</Codenesium>*/