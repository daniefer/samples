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
	[Route("api/postHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PostHistoryController : AbstractPostHistoryController
	{
		public PostHistoryController(
			ApiSettings settings,
			ILogger<PostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryService postHistoryService,
			IApiPostHistoryModelMapper postHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postHistoryService,
			       postHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ca2358f70773c23223ed25eb9de15752</Hash>
</Codenesium>*/