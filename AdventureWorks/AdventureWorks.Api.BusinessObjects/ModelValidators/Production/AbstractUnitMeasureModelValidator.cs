using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiUnitMeasureModelValidator: AbstractValidator<ApiUnitMeasureModel>
	{
		public new ValidationResult Validate(ApiUnitMeasureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IUnitMeasureRepository UnitMeasureRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiUnitMeasureModel model)
		{
			return this.UnitMeasureRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>9724f4ac9c776c6305f2987d8c7af188</Hash>
</Codenesium>*/