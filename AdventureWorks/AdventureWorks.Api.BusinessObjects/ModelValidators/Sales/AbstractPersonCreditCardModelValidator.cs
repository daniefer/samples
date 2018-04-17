using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractPersonCreditCardModelValidator: AbstractValidator<PersonCreditCardModel>
	{
		public new ValidationResult Validate(PersonCreditCardModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PersonCreditCardModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository { get; set; }
		public ICreditCardRepository CreditCardRepository { get; set; }
		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).NotNull();
			this.RuleFor(x => x.CreditCardID).Must(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidCreditCard(int id)
		{
			return this.CreditCardRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>27a3807e2415e38825f8d5d02bc09f4e</Hash>
</Codenesium>*/