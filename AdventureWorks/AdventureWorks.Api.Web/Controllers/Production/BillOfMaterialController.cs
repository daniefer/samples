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
	[Route("api/billOfMaterials")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BillOfMaterialController : AbstractBillOfMaterialController
	{
		public BillOfMaterialController(
			ApiSettings settings,
			ILogger<BillOfMaterialController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialService billOfMaterialService,
			IApiBillOfMaterialModelMapper billOfMaterialModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       billOfMaterialService,
			       billOfMaterialModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>afab04e38336c20fa7b7d7162ca9b866</Hash>
</Codenesium>*/