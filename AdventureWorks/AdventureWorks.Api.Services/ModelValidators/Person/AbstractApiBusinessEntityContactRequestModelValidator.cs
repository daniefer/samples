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
	public abstract class AbstractApiBusinessEntityContactRequestModelValidator : AbstractValidator<ApiBusinessEntityContactRequestModel>
	{
		private int existingRecordId;

		private IBusinessEntityContactRepository businessEntityContactRepository;

		public AbstractApiBusinessEntityContactRequestModelValidator(IBusinessEntityContactRepository businessEntityContactRepository)
		{
			this.businessEntityContactRepository = businessEntityContactRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContactTypeIDRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PersonIDRules()
		{
		}

		public virtual void RowguidRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>173aa78ad4dafd87faa464824ea8ed57</Hash>
</Codenesium>*/