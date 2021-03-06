using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiProjectRequestModelValidator : AbstractApiProjectRequestModelValidator, IApiProjectRequestModelValidator
	{
		public ApiProjectRequestModelValidator(IProjectRepository projectRepository)
			: base(projectRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProjectRequestModel model)
		{
			this.AutoCreateReleaseRules();
			this.DataVersionRules();
			this.DeploymentProcessIdRules();
			this.DiscreteChannelReleaseRules();
			this.IncludedLibraryVariableSetIdsRules();
			this.IsDisabledRules();
			this.JSONRules();
			this.LifecycleIdRules();
			this.NameRules();
			this.ProjectGroupIdRules();
			this.SlugRules();
			this.VariableSetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectRequestModel model)
		{
			this.AutoCreateReleaseRules();
			this.DataVersionRules();
			this.DeploymentProcessIdRules();
			this.DiscreteChannelReleaseRules();
			this.IncludedLibraryVariableSetIdsRules();
			this.IsDisabledRules();
			this.JSONRules();
			this.LifecycleIdRules();
			this.NameRules();
			this.ProjectGroupIdRules();
			this.SlugRules();
			this.VariableSetIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ef59d79eac972ed30c0a4387f72ed16c</Hash>
</Codenesium>*/