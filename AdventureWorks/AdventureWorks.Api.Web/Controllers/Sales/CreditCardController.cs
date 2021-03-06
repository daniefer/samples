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
	[Route("api/creditCards")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CreditCardController : AbstractCreditCardController
	{
		public CreditCardController(
			ApiSettings settings,
			ILogger<CreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardService creditCardService,
			IApiCreditCardModelMapper creditCardModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       creditCardService,
			       creditCardModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4fc1c7b837a4db26bb7ad7d668193378</Hash>
</Codenesium>*/