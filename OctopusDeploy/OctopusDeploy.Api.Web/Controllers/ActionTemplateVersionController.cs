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
	[Route("api/actionTemplateVersions")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ActionTemplateVersionController : AbstractActionTemplateVersionController
	{
		public ActionTemplateVersionController(
			ApiSettings settings,
			ILogger<ActionTemplateVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IActionTemplateVersionService actionTemplateVersionService,
			IApiActionTemplateVersionModelMapper actionTemplateVersionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       actionTemplateVersionService,
			       actionTemplateVersionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b98f1b2d0e5607e372b0a1e35791315b</Hash>
</Codenesium>*/