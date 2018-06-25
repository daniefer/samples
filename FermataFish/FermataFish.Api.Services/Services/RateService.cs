using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public partial class RateService : AbstractRateService, IRateService
        {
                public RateService(
                        ILogger<IRateRepository> logger,
                        IRateRepository rateRepository,
                        IApiRateRequestModelValidator rateModelValidator,
                        IBOLRateMapper bolrateMapper,
                        IDALRateMapper dalrateMapper
                        )
                        : base(logger,
                               rateRepository,
                               rateModelValidator,
                               bolrateMapper,
                               dalrateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>30f6866e37a1d78f44d02426fe14aa4a</Hash>
</Codenesium>*/