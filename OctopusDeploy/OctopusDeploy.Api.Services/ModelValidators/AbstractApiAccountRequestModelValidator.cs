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
	public abstract class AbstractApiAccountRequestModelValidator : AbstractValidator<ApiAccountRequestModel>
	{
		private string existingRecordId;

		private IAccountRepository accountRepository;

		public AbstractApiAccountRequestModelValidator(IAccountRepository accountRepository)
		{
			this.accountRepository = accountRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAccountRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountTypeRules()
		{
			this.RuleFor(x => x.AccountType).Length(0, 50);
		}

		public virtual void EnvironmentIdsRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAccountRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void TenantIdsRules()
		{
		}

		public virtual void TenantTagsRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiAccountRequestModel model,  CancellationToken cancellationToken)
		{
			Account record = await this.accountRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2687d28861902323d41372b96696f106</Hash>
</Codenesium>*/