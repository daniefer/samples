using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Web
{
	[Route("api/versionInfoes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class VersionInfoController : AbstractVersionInfoController
	{
		public VersionInfoController(
			ApiSettings settings,
			ILogger<VersionInfoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVersionInfoService versionInfoService,
			IApiVersionInfoModelMapper versionInfoModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       versionInfoService,
			       versionInfoModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0689fa48111bc75cd0b4d02baea31072</Hash>
</Codenesium>*/