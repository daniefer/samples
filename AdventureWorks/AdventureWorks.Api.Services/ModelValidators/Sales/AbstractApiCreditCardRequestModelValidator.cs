using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCreditCardRequestModelValidator : AbstractValidator<ApiCreditCardRequestModel>
	{
		private int existingRecordId;

		private ICreditCardRepository creditCardRepository;

		public AbstractApiCreditCardRequestModelValidator(ICreditCardRepository creditCardRepository)
		{
			this.creditCardRepository = creditCardRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCreditCardRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CardNumberRules()
		{
			this.RuleFor(x => x.CardNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCardNumber).When(x => x?.CardNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCreditCardRequestModel.CardNumber));
			this.RuleFor(x => x.CardNumber).Length(0, 25);
		}

		public virtual void CardTypeRules()
		{
			this.RuleFor(x => x.CardType).NotNull();
			this.RuleFor(x => x.CardType).Length(0, 50);
		}

		public virtual void ExpMonthRules()
		{
		}

		public virtual void ExpYearRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		private async Task<bool> BeUniqueByCardNumber(ApiCreditCardRequestModel model,  CancellationToken cancellationToken)
		{
			CreditCard record = await this.creditCardRepository.ByCardNumber(model.CardNumber);

			if (record == null || (this.existingRecordId != default(int) && record.CreditCardID == this.existingRecordId))
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
    <Hash>60396eb6a6dea4d12985f85df2e96fb6</Hash>
</Codenesium>*/