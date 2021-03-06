using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineService : AbstractPipelineService, IPipelineService
	{
		public PipelineService(
			ILogger<IPipelineRepository> logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolpipelineMapper,
			IDALPipelineMapper dalpipelineMapper
			)
			: base(logger,
			       pipelineRepository,
			       pipelineModelValidator,
			       bolpipelineMapper,
			       dalpipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8a420df3b743bb998400f6b07a417522</Hash>
</Codenesium>*/