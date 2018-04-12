using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/chains")]
	public class ChainController: AbstractChainController
	{
		public ChainController(
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       chainRepository,
			       chainModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e304cfa862bf4c36392f14268d827a86</Hash>
</Codenesium>*/