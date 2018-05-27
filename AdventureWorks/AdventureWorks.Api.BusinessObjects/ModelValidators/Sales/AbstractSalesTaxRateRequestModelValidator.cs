using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesTaxRateRequestModelValidator: AbstractValidator<ApiSalesTaxRateRequestModel>
	{
		public new ValidationResult Validate(ApiSalesTaxRateRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTaxRateRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesTaxRateRepository SalesTaxRateRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceIDTaxType).When(x => x ?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.StateProvinceID));
		}

		public virtual void TaxRateRules()
		{
			this.RuleFor(x => x.TaxRate).NotNull();
		}

		public virtual void TaxTypeRules()
		{
			this.RuleFor(x => x.TaxType).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceIDTaxType).When(x => x ?.TaxType != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.TaxType));
		}

		private async Task<bool> BeUniqueGetStateProvinceIDTaxType(ApiSalesTaxRateRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.SalesTaxRateRepository.GetStateProvinceIDTaxType(model.StateProvinceID,model.TaxType);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>6aadcb62369775f6c3feee8588aa1ffa</Hash>
</Codenesium>*/