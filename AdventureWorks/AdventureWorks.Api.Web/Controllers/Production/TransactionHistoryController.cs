using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/transactionHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TransactionHistoryController : AbstractTransactionHistoryController
	{
		public TransactionHistoryController(
			ApiSettings settings,
			ILogger<TransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryService transactionHistoryService,
			IApiTransactionHistoryModelMapper transactionHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionHistoryService,
			       transactionHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4b4a207dd6115e1c5df26b44b4bcece6</Hash>
</Codenesium>*/