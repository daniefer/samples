using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
	[Route("api/airlines")]
	[ApiController]
	[ApiVersion("1.0")]
	public class AirlineController : AbstractAirlineController
	{
		public AirlineController(
			ApiSettings settings,
			ILogger<AirlineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAirlineService airlineService,
			IApiAirlineModelMapper airlineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airlineService,
			       airlineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4c1a24004d4b0128403b88aac299fd7f</Hash>
</Codenesium>*/