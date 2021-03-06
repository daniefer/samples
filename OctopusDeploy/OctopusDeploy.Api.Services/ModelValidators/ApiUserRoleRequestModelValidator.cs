using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiUserRoleRequestModelValidator : AbstractApiUserRoleRequestModelValidator, IApiUserRoleRequestModelValidator
	{
		public ApiUserRoleRequestModelValidator(IUserRoleRepository userRoleRepository)
			: base(userRoleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserRoleRequestModel model)
		{
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRoleRequestModel model)
		{
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>18657ef2c13993e6f0f44c4b5ea8c22d</Hash>
</Codenesium>*/