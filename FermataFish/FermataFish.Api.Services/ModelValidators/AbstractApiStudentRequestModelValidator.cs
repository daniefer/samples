using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractApiStudentRequestModelValidator : AbstractValidator<ApiStudentRequestModel>
	{
		private int existingRecordId;

		private IStudentRepository studentRepository;

		public AbstractApiStudentRequestModelValidator(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudentRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BirthdayRules()
		{
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void EmailRemindersEnabledRules()
		{
		}

		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x?.FamilyId != null).WithMessage("Invalid reference");
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void IsAdultRules()
		{
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 128);
		}

		public virtual void SmsRemindersEnabledRules()
		{
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidFamily(int id,  CancellationToken cancellationToken)
		{
			var record = await this.studentRepository.GetFamily(id);

			return record != null;
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.studentRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8f7e1ae3c0f6339027aa05297baac28b</Hash>
</Codenesium>*/