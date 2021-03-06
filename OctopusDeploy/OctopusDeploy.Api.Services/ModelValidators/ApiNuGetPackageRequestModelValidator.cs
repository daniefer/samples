using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiNuGetPackageRequestModelValidator : AbstractApiNuGetPackageRequestModelValidator, IApiNuGetPackageRequestModelValidator
	{
		public ApiNuGetPackageRequestModelValidator(INuGetPackageRepository nuGetPackageRepository)
			: base(nuGetPackageRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiNuGetPackageRequestModel model)
		{
			this.JSONRules();
			this.PackageIdRules();
			this.VersionRules();
			this.VersionBuildRules();
			this.VersionMajorRules();
			this.VersionMinorRules();
			this.VersionRevisionRules();
			this.VersionSpecialRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiNuGetPackageRequestModel model)
		{
			this.JSONRules();
			this.PackageIdRules();
			this.VersionRules();
			this.VersionBuildRules();
			this.VersionMajorRules();
			this.VersionMinorRules();
			this.VersionRevisionRules();
			this.VersionSpecialRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>959a7fb2897b5a982b7a98e7c5beec32</Hash>
</Codenesium>*/