using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOPipelineStep: AbstractBOManager
	{
		private IPipelineStepRepository pipelineStepRepository;
		private IApiPipelineStepModelValidator pipelineStepModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStep(
			ILogger logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepModelValidator pipelineStepModelValidator)
			: base()

		{
			this.pipelineStepRepository = pipelineStepRepository;
			this.pipelineStepModelValidator = pipelineStepModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPipelineStep> Get(int id)
		{
			return this.pipelineStepRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStep>> Create(
			ApiPipelineStepModel model)
		{
			CreateResponse<POCOPipelineStep> response = new CreateResponse<POCOPipelineStep>(await this.pipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStep record = await this.pipelineStepRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.pipelineStepRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4abcada7b895c1dcf7912544f5d42798</Hash>
</Codenesium>*/