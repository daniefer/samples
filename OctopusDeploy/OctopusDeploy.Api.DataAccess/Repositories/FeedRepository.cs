using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class FeedRepository : AbstractFeedRepository, IFeedRepository
        {
                public FeedRepository(
                        ILogger<FeedRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c7ab8ddb87c439fd25684e67ba0ece2f</Hash>
</Codenesium>*/