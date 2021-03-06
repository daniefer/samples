using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Web
{
	[Route("api/badges")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BadgesController : AbstractBadgesController
	{
		public BadgesController(
			ApiSettings settings,
			ILogger<BadgesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBadgesService badgesService,
			IApiBadgesModelMapper badgesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       badgesService,
			       badgesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>38841f54ed8718d738e3a8e475687f1b</Hash>
</Codenesium>*/