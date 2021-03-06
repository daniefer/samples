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
	[Route("api/salesTerritoryHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SalesTerritoryHistoryController : AbstractSalesTerritoryHistoryController
	{
		public SalesTerritoryHistoryController(
			ApiSettings settings,
			ILogger<SalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryHistoryService salesTerritoryHistoryService,
			IApiSalesTerritoryHistoryModelMapper salesTerritoryHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesTerritoryHistoryService,
			       salesTerritoryHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5cf5e25dbfe44d5654e84a0a67072c04</Hash>
</Codenesium>*/