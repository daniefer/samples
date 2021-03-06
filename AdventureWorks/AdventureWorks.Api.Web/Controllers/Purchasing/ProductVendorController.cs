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
	[Route("api/productVendors")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductVendorController : AbstractProductVendorController
	{
		public ProductVendorController(
			ApiSettings settings,
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorService productVendorService,
			IApiProductVendorModelMapper productVendorModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productVendorService,
			       productVendorModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eea3b389e4821cc481710b2860479908</Hash>
</Codenesium>*/