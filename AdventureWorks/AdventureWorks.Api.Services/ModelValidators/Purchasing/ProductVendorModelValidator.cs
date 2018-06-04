using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductVendorRequestModelValidator: AbstractApiProductVendorRequestModelValidator, IApiProductVendorRequestModelValidator
	{
		public ApiProductVendorRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c59b299ddc90b1d41b83d4bf8d884f4c</Hash>
</Codenesium>*/