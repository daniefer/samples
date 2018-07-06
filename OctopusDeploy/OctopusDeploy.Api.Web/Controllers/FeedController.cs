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
        [Route("api/feeds")]
        [ApiController]
        [ApiVersion("1.0")]
        public class FeedController : AbstractFeedController
        {
                public FeedController(
                        ApiSettings settings,
                        ILogger<FeedController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFeedService feedService,
                        IApiFeedModelMapper feedModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               feedService,
                               feedModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>17aed5a7e00b9b1c5239dcfa25f9b924</Hash>
</Codenesium>*/