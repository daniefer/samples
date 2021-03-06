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
	public abstract class AbstractApiSchemaAPersonRequestModelValidator : AbstractValidator<ApiSchemaAPersonRequestModel>
	{
		private int existingRecordId;

		private ISchemaAPersonRepository schemaAPersonRepository;

		public AbstractApiSchemaAPersonRequestModelValidator(ISchemaAPersonRepository schemaAPersonRepository)
		{
			this.schemaAPersonRepository = schemaAPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSchemaAPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>407b887489dbe161b44c728c7d3e67ef</Hash>
</Codenesium>*/