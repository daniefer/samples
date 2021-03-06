using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiPostTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>49465e7e21dbbd6513f33f0271824ec3</Hash>
</Codenesium>*/