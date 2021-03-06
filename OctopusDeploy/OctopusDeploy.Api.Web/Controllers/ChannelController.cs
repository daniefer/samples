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
	[Route("api/channels")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ChannelController : AbstractChannelController
	{
		public ChannelController(
			ApiSettings settings,
			ILogger<ChannelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChannelService channelService,
			IApiChannelModelMapper channelModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       channelService,
			       channelModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a1a6e56be77b2a98cac9aa36ca07353b</Hash>
</Codenesium>*/