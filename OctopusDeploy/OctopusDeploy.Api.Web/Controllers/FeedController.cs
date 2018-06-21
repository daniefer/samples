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
        [ApiVersion("1.0")]
        public class FeedController : AbstractFeedController
        {
                public FeedController(
                        ApiSettings settings,
                        ILogger<FeedController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFeedService feedService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               feedService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5d5ed1b22ef5e9703affedae59ccb293</Hash>
</Codenesium>*/