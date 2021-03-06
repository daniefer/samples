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
	[Route("api/countryRequirements")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CountryRequirementController : AbstractCountryRequirementController
	{
		public CountryRequirementController(
			ApiSettings settings,
			ILogger<CountryRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRequirementService countryRequirementService,
			IApiCountryRequirementModelMapper countryRequirementModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRequirementService,
			       countryRequirementModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d16355fc2fd8d1b85515a8db9a2f4af3</Hash>
</Codenesium>*/