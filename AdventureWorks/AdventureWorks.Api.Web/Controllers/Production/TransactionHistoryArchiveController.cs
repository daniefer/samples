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
	[Route("api/transactionHistoryArchives")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TransactionHistoryArchiveController : AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ApiSettings settings,
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveService transactionHistoryArchiveService,
			IApiTransactionHistoryArchiveModelMapper transactionHistoryArchiveModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionHistoryArchiveService,
			       transactionHistoryArchiveModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>12da1f967968447e46391eae791826b9</Hash>
</Codenesium>*/