using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
	[Route("api/families")]
	[ApiController]
	[ApiVersion("1.0")]
	public class FamilyController : AbstractFamilyController
	{
		public FamilyController(
			ApiSettings settings,
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyService familyService,
			IApiFamilyModelMapper familyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       familyService,
			       familyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b2f3e12963f7f638a6e088996c7fe676</Hash>
</Codenesium>*/