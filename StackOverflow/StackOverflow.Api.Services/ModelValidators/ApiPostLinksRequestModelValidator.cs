using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostLinksRequestModelValidator : AbstractApiPostLinksRequestModelValidator, IApiPostLinksRequestModelValidator
	{
		public ApiPostLinksRequestModelValidator(IPostLinksRepository postLinksRepository)
			: base(postLinksRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostLinksRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinksRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3174ab8e9bdfb137799030eef4faa89b</Hash>
</Codenesium>*/