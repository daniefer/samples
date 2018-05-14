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
	public abstract class AbstractBOPipelineStepNote
	{
		private IPipelineStepNoteRepository pipelineStepNoteRepository;
		private IPipelineStepNoteModelValidator pipelineStepNoteModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepNote(
			ILogger logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IPipelineStepNoteModelValidator pipelineStepNoteModelValidator)

		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
			this.pipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepNoteRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipelineStepNote Get(int id)
		{
			return this.pipelineStepNoteRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepNote>> Create(
			PipelineStepNoteModel model)
		{
			CreateResponse<POCOPipelineStepNote> response = new CreateResponse<POCOPipelineStepNote>(await this.pipelineStepNoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepNote record = this.pipelineStepNoteRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepNoteModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepNoteRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepNoteRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8ff47e136fdc26eae460e9d0795bc69d</Hash>
</Codenesium>*/