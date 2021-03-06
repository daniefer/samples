using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiProjectTriggerRequestModelValidator : AbstractApiProjectTriggerRequestModelValidator, IApiProjectTriggerRequestModelValidator
	{
		public ApiProjectTriggerRequestModelValidator(IProjectTriggerRepository projectTriggerRepository)
			: base(projectTriggerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProjectTriggerRequestModel model)
		{
			this.IsDisabledRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdRules();
			this.TriggerTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectTriggerRequestModel model)
		{
			this.IsDisabledRules();
			this.JSONRules();
			this.NameRules();
			this.ProjectIdRules();
			this.TriggerTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a7d58f3c23d3b3ff5f665dd00171e6f5</Hash>
</Codenesium>*/