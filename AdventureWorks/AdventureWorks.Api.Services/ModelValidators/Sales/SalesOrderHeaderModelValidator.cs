using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesOrderHeaderRequestModelValidator: AbstractApiSalesOrderHeaderRequestModelValidator, IApiSalesOrderHeaderRequestModelValidator
	{
		public ApiSalesOrderHeaderRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderRequestModel model)
		{
			this.AccountNumberRules();
			this.BillToAddressIDRules();
			this.CommentRules();
			this.CreditCardApprovalCodeRules();
			this.CreditCardIDRules();
			this.CurrencyRateIDRules();
			this.CustomerIDRules();
			this.DueDateRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OnlineOrderFlagRules();
			this.OrderDateRules();
			this.PurchaseOrderNumberRules();
			this.RevisionNumberRules();
			this.RowguidRules();
			this.SalesOrderNumberRules();
			this.SalesPersonIDRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.ShipToAddressIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TerritoryIDRules();
			this.TotalDueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderRequestModel model)
		{
			this.AccountNumberRules();
			this.BillToAddressIDRules();
			this.CommentRules();
			this.CreditCardApprovalCodeRules();
			this.CreditCardIDRules();
			this.CurrencyRateIDRules();
			this.CustomerIDRules();
			this.DueDateRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OnlineOrderFlagRules();
			this.OrderDateRules();
			this.PurchaseOrderNumberRules();
			this.RevisionNumberRules();
			this.RowguidRules();
			this.SalesOrderNumberRules();
			this.SalesPersonIDRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.ShipToAddressIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TerritoryIDRules();
			this.TotalDueRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2f62897d0c9ecc3aa6e393fb38aa7b85</Hash>
</Codenesium>*/