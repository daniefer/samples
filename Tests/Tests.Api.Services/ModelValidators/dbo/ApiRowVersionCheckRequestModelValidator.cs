using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiRowVersionCheckRequestModelValidator : AbstractApiRowVersionCheckRequestModelValidator, IApiRowVersionCheckRequestModelValidator
	{
		public ApiRowVersionCheckRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
			: base(rowVersionCheckRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c543bb25a7cf23fd6b57055306a18c99</Hash>
</Codenesium>*/