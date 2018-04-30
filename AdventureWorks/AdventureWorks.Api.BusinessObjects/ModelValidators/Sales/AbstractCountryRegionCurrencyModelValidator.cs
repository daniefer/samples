using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractCountryRegionCurrencyModelValidator: AbstractValidator<CountryRegionCurrencyModel>
	{
		public new ValidationResult Validate(CountryRegionCurrencyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CountryRegionCurrencyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICurrencyRepository CurrencyRepository { get; set; }
		public virtual void CurrencyCodeRules()
		{
			this.RuleFor(x => x.CurrencyCode).NotNull();
			this.RuleFor(x => x.CurrencyCode).Must(this.BeValidCurrency).When(x => x ?.CurrencyCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.CurrencyCode).Length(0, 3);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCurrency(string id)
		{
			return this.CurrencyRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>e64edfa16fcfbd5878980050f1d5e0ee</Hash>
</Codenesium>*/