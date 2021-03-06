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
	public abstract class AbstractApiIllustrationRequestModelValidator : AbstractValidator<ApiIllustrationRequestModel>
	{
		private int existingRecordId;

		private IIllustrationRepository illustrationRepository;

		public AbstractApiIllustrationRequestModelValidator(IIllustrationRepository illustrationRepository)
		{
			this.illustrationRepository = illustrationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIllustrationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DiagramRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0967a5d4b83a3e8d7b54d61cda1b2af4</Hash>
</Codenesium>*/