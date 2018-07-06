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
        [Route("api/pipelineSteps")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PipelineStepController : AbstractPipelineStepController
        {
                public PipelineStepController(
                        ApiSettings settings,
                        ILogger<PipelineStepController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepService pipelineStepService,
                        IApiPipelineStepModelMapper pipelineStepModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepService,
                               pipelineStepModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b0b8d18007070085454b8ed43e061a92</Hash>
</Codenesium>*/