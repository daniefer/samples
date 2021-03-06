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
	[Route("api/extensionConfigurations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ExtensionConfigurationController : AbstractExtensionConfigurationController
	{
		public ExtensionConfigurationController(
			ApiSettings settings,
			ILogger<ExtensionConfigurationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IExtensionConfigurationService extensionConfigurationService,
			IApiExtensionConfigurationModelMapper extensionConfigurationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       extensionConfigurationService,
			       extensionConfigurationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3c2f2f7c70306b8a7ed0120623fe9829</Hash>
</Codenesium>*/