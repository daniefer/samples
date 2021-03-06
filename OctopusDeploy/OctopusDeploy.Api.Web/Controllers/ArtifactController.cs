using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/artifacts")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ArtifactController : AbstractArtifactController
	{
		public ArtifactController(
			ApiSettings settings,
			ILogger<ArtifactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IArtifactService artifactService,
			IApiArtifactModelMapper artifactModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       artifactService,
			       artifactModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ca5ecb9560bde6e5d6e8e32bc3511841</Hash>
</Codenesium>*/