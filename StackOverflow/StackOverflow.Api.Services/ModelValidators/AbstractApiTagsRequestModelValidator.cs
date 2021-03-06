using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiTagsRequestModelValidator : AbstractValidator<ApiTagsRequestModel>
	{
		private int existingRecordId;

		private ITagsRepository tagsRepository;

		public AbstractApiTagsRequestModelValidator(ITagsRepository tagsRepository)
		{
			this.tagsRepository = tagsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTagsRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountRules()
		{
		}

		public virtual void ExcerptPostIdRules()
		{
		}

		public virtual void TagNameRules()
		{
			this.RuleFor(x => x.TagName).Length(0, 150);
		}

		public virtual void WikiPostIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9a573b919b68bcf4f28982c1c37cc6e4</Hash>
</Codenesium>*/