using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiStudioRequestModelValidator : AbstractApiStudioRequestModelValidator, IApiStudioRequestModelValidator
	{
		public ApiStudioRequestModelValidator(IStudioRepository studioRepository)
			: base(studioRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2fba0444e3a64fbe6509f6c3a82a876f</Hash>
</Codenesium>*/