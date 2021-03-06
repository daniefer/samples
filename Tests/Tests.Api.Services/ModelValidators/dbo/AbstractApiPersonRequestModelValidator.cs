using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiPersonRequestModelValidator : AbstractValidator<ApiPersonRequestModel>
	{
		private int existingRecordId;

		private IPersonRepository personRepository;

		public AbstractApiPersonRequestModelValidator(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull();
			this.RuleFor(x => x.PersonName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>af3bfd75400be5ae3ab756756e2b792e</Hash>
</Codenesium>*/