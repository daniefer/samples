using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStatusRequestModelValidator : AbstractValidator<ApiPipelineStatusRequestModel>
	{
		private int existingRecordId;

		private IPipelineStatusRepository pipelineStatusRepository;

		public AbstractApiPipelineStatusRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
		{
			this.pipelineStatusRepository = pipelineStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>82cc8ceb10107ec2b1d45baf7968c42d</Hash>
</Codenesium>*/