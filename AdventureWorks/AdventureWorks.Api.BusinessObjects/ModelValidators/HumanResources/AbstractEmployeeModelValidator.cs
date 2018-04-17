using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractEmployeeModelValidator: AbstractValidator<EmployeeModel>
	{
		public new ValidationResult Validate(EmployeeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository { get; set; }
		public virtual void NationalIDNumberRules()
		{
			this.RuleFor(x => x.NationalIDNumber).NotNull();
			this.RuleFor(x => x.NationalIDNumber).Length(0, 15);
		}

		public virtual void LoginIDRules()
		{
			this.RuleFor(x => x.LoginID).NotNull();
			this.RuleFor(x => x.LoginID).Length(0, 256);
		}

		public virtual void OrganizationNodeRules()
		{                       }

		public virtual void OrganizationLevelRules()
		{                       }

		public virtual void JobTitleRules()
		{
			this.RuleFor(x => x.JobTitle).NotNull();
			this.RuleFor(x => x.JobTitle).Length(0, 50);
		}

		public virtual void BirthDateRules()
		{
			this.RuleFor(x => x.BirthDate).NotNull();
		}

		public virtual void MaritalStatusRules()
		{
			this.RuleFor(x => x.MaritalStatus).NotNull();
			this.RuleFor(x => x.MaritalStatus).Length(0, 1);
		}

		public virtual void GenderRules()
		{
			this.RuleFor(x => x.Gender).NotNull();
			this.RuleFor(x => x.Gender).Length(0, 1);
		}

		public virtual void HireDateRules()
		{
			this.RuleFor(x => x.HireDate).NotNull();
		}

		public virtual void SalariedFlagRules()
		{
			this.RuleFor(x => x.SalariedFlag).NotNull();
		}

		public virtual void VacationHoursRules()
		{
			this.RuleFor(x => x.VacationHours).NotNull();
		}

		public virtual void SickLeaveHoursRules()
		{
			this.RuleFor(x => x.SickLeaveHours).NotNull();
		}

		public virtual void CurrentFlagRules()
		{
			this.RuleFor(x => x.CurrentFlag).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>80388ba6b9f204578b9e83fb8cacabb6</Hash>
</Codenesium>*/