using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiLibraryVariableSetRequestModelValidator : AbstractApiLibraryVariableSetRequestModelValidator, IApiLibraryVariableSetRequestModelValidator
	{
		public ApiLibraryVariableSetRequestModelValidator(ILibraryVariableSetRepository libraryVariableSetRepository)
			: base(libraryVariableSetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model)
		{
			this.ContentTypeRules();
			this.JSONRules();
			this.NameRules();
			this.VariableSetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model)
		{
			this.ContentTypeRules();
			this.JSONRules();
			this.NameRules();
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
    <Hash>d8525417a7c13c646c7e2d421b3005f0</Hash>
</Codenesium>*/