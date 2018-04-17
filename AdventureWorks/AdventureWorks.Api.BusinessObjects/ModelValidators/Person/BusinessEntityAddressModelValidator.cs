using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BusinessEntityAddressModelValidator: AbstractBusinessEntityAddressModelValidator, IBusinessEntityAddressModelValidator
	{
		public BusinessEntityAddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BusinessEntityAddressModel model)
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityAddressModel model)
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>541049f250f94e987f2887c3faa30e1d</Hash>
</Codenesium>*/