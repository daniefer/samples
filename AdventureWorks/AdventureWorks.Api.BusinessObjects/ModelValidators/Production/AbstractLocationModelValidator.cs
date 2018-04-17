using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractLocationModelValidator: AbstractValidator<LocationModel>
	{
		public new ValidationResult Validate(LocationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LocationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void CostRateRules()
		{
			this.RuleFor(x => x.CostRate).NotNull();
		}

		public virtual void AvailabilityRules()
		{
			this.RuleFor(x => x.Availability).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>dd91e1e2a47967f839e2f19de48b3f40</Hash>
</Codenesium>*/