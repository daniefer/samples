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
        [Route("api/handlerPipelineSteps")]
        [ApiController]
        [ApiVersion("1.0")]
        public class HandlerPipelineStepController : AbstractHandlerPipelineStepController
        {
                public HandlerPipelineStepController(
                        ApiSettings settings,
                        ILogger<HandlerPipelineStepController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IHandlerPipelineStepService handlerPipelineStepService,
                        IApiHandlerPipelineStepModelMapper handlerPipelineStepModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               handlerPipelineStepService,
                               handlerPipelineStepModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>828fca8e4c2e144c4fb6add5cf5b86ca</Hash>
</Codenesium>*/