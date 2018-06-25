using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ReleaseRepository : AbstractReleaseRepository, IReleaseRepository
        {
                public ReleaseRepository(
                        ILogger<ReleaseRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7baadcd20eb7d8055078748e93b59e9f</Hash>
</Codenesium>*/