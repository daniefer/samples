using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiDashboardConfigurationRequestModelValidator : AbstractApiDashboardConfigurationRequestModelValidator, IApiDashboardConfigurationRequestModelValidator
	{
		public ApiDashboardConfigurationRequestModelValidator(IDashboardConfigurationRepository dashboardConfigurationRepository)
			: base(dashboardConfigurationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDashboardConfigurationRequestModel model)
		{
			this.IncludedEnvironmentIdsRules();
			this.IncludedProjectIdsRules();
			this.IncludedTenantIdsRules();
			this.IncludedTenantTagsRules();
			this.JSONRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDashboardConfigurationRequestModel model)
		{
			this.IncludedEnvironmentIdsRules();
			this.IncludedProjectIdsRules();
			this.IncludedTenantIdsRules();
			this.IncludedTenantTagsRules();
			this.JSONRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>49f10d1f0ddc849711e81e01226473a2</Hash>
</Codenesium>*/