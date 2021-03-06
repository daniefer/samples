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
	[Route("api/votes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class VotesController : AbstractVotesController
	{
		public VotesController(
			ApiSettings settings,
			ILogger<VotesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVotesService votesService,
			IApiVotesModelMapper votesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       votesService,
			       votesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8b5c7845457c351e07334ed69225f80f</Hash>
</Codenesium>*/