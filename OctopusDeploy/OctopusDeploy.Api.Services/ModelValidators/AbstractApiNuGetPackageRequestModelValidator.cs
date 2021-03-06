using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiNuGetPackageRequestModelValidator : AbstractValidator<ApiNuGetPackageRequestModel>
	{
		private string existingRecordId;

		private INuGetPackageRepository nuGetPackageRepository;

		public AbstractApiNuGetPackageRequestModelValidator(INuGetPackageRepository nuGetPackageRepository)
		{
			this.nuGetPackageRepository = nuGetPackageRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiNuGetPackageRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void PackageIdRules()
		{
			this.RuleFor(x => x.PackageId).Length(0, 100);
		}

		public virtual void VersionRules()
		{
			this.RuleFor(x => x.Version).Length(0, 349);
		}

		public virtual void VersionBuildRules()
		{
		}

		public virtual void VersionMajorRules()
		{
		}

		public virtual void VersionMinorRules()
		{
		}

		public virtual void VersionRevisionRules()
		{
		}

		public virtual void VersionSpecialRules()
		{
			this.RuleFor(x => x.VersionSpecial).Length(0, 250);
		}
	}
}

/*<Codenesium>
    <Hash>ea6d24db346867330d23cf16ebc78b63</Hash>
</Codenesium>*/