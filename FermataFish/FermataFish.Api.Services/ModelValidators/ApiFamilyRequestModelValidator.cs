using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiFamilyRequestModelValidator : AbstractApiFamilyRequestModelValidator, IApiFamilyRequestModelValidator
	{
		public ApiFamilyRequestModelValidator(IFamilyRepository familyRepository)
			: base(familyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model)
		{
			this.NotesRules();
			this.PcEmailRules();
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model)
		{
			this.NotesRules();
			this.PcEmailRules();
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5d93d7be03afa614f75494ebcfd53927</Hash>
</Codenesium>*/