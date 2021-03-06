using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiFeedRequestModelValidator : AbstractApiFeedRequestModelValidator, IApiFeedRequestModelValidator
	{
		public ApiFeedRequestModelValidator(IFeedRepository feedRepository)
			: base(feedRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model)
		{
			this.FeedTypeRules();
			this.FeedUriRules();
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model)
		{
			this.FeedTypeRules();
			this.FeedUriRules();
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>57cc75812a5d2abc4a59a6eb0bb1c4df</Hash>
</Codenesium>*/