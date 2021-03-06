using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiActionTemplateRequestModelValidator : AbstractApiActionTemplateRequestModelValidator, IApiActionTemplateRequestModelValidator
	{
		public ApiActionTemplateRequestModelValidator(IActionTemplateRepository actionTemplateRepository)
			: base(actionTemplateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model)
		{
			this.ActionTypeRules();
			this.CommunityActionTemplateIdRules();
			this.JSONRules();
			this.NameRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model)
		{
			this.ActionTypeRules();
			this.CommunityActionTemplateIdRules();
			this.JSONRules();
			this.NameRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a8fa14bf355a4e817f29df8deb45f47e</Hash>
</Codenesium>*/