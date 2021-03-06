using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBusinessEntityContactRequestModelValidator : AbstractApiBusinessEntityContactRequestModelValidator, IApiBusinessEntityContactRequestModelValidator
	{
		public ApiBusinessEntityContactRequestModelValidator(IBusinessEntityContactRepository businessEntityContactRepository)
			: base(businessEntityContactRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3d4b8de2c11735f6df6e01d7098724c9</Hash>
</Codenesium>*/