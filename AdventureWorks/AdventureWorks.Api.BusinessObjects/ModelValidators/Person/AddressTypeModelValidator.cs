using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class AddressTypeModelValidator: AbstractAddressTypeModelValidator, IAddressTypeModelValidator
	{
		public AddressTypeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AddressTypeModel model)
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AddressTypeModel model)
		{
			this.NameRules();
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
    <Hash>256af26824eb761bdc3f028fd27f1330</Hash>
</Codenesium>*/