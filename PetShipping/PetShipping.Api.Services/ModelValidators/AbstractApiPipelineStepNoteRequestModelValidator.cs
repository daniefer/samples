using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepNoteRequestModelValidator : AbstractValidator<ApiPipelineStepNoteRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepNoteRepository pipelineStepNoteRepository;

		public AbstractApiPipelineStepNoteRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepNoteRepository.GetEmployee(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepNoteRepository.GetPipelineStep(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b227fb2fdbd650b521c3da5a3574dca1</Hash>
</Codenesium>*/