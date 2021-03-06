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
	[Route("api/documents")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DocumentController : AbstractDocumentController
	{
		public DocumentController(
			ApiSettings settings,
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentService documentService,
			IApiDocumentModelMapper documentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       documentService,
			       documentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>065c18aec1687d80cd9fb745f3f6c7e0</Hash>
</Codenesium>*/