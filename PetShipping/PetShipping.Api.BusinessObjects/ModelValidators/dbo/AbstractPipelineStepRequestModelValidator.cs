using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStepRequestModelValidator: AbstractValidator<ApiPipelineStepRequestModel>
	{
		public new ValidationResult Validate(ApiPipelineStepRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPipelineStepStatusRepository PipelineStepStatusRepository { get; set; }
		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void PipelineStepStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStepStatusId).NotNull();
			this.RuleFor(x => x.PipelineStepStatusId).MustAsync(this.BeValidPipelineStepStatus).When(x => x ?.PipelineStepStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ShipperIdRules()
		{
			this.RuleFor(x => x.ShipperId).NotNull();
			this.RuleFor(x => x.ShipperId).MustAsync(this.BeValidEmployee).When(x => x ?.ShipperId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidPipelineStepStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepStatusRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EmployeeRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d491e9ce5cc3b0c6bf18ee6797dfa54f</Hash>
</Codenesium>*/