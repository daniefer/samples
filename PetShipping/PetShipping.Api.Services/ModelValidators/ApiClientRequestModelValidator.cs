using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiClientRequestModelValidator : AbstractApiClientRequestModelValidator, IApiClientRequestModelValidator
	{
		public ApiClientRequestModelValidator(IClientRepository clientRepository)
			: base(clientRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NotesRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NotesRules();
			this.PhoneRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5570535d87a8a9655c140f39bb3e27e4</Hash>
</Codenesium>*/