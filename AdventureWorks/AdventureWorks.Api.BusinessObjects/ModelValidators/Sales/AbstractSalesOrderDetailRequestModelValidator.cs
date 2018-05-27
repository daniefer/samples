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
	public abstract class AbstractApiSalesOrderDetailRequestModelValidator: AbstractValidator<ApiSalesOrderDetailRequestModel>
	{
		public new ValidationResult Validate(ApiSalesOrderDetailRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderDetailRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpecialOfferProductRepository SpecialOfferProductRepository { get; set; }
		public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }
		public virtual void CarrierTrackingNumberRules()
		{
			this.RuleFor(x => x.CarrierTrackingNumber).Length(0, 25);
		}

		public virtual void LineTotalRules()
		{
			this.RuleFor(x => x.LineTotal).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesOrderDetailIDRules()
		{
			this.RuleFor(x => x.SalesOrderDetailID).NotNull();
		}

		public virtual void SpecialOfferIDRules()
		{
			this.RuleFor(x => x.SpecialOfferID).NotNull();
			this.RuleFor(x => x.SpecialOfferID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x ?.SpecialOfferID != null).WithMessage("Invalid reference");
		}

		public virtual void UnitPriceRules()
		{
			this.RuleFor(x => x.UnitPrice).NotNull();
		}

		public virtual void UnitPriceDiscountRules()
		{
			this.RuleFor(x => x.UnitPriceDiscount).NotNull();
		}

		private async Task<bool> BeValidSpecialOfferProduct(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpecialOfferProductRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesOrderHeader(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>2a27c722d55f03a860518c6fcd65020c</Hash>
</Codenesium>*/