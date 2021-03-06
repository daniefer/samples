using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiServerTaskRequestModelValidator : AbstractValidator<ApiServerTaskRequestModel>
	{
		private string existingRecordId;

		private IServerTaskRepository serverTaskRepository;

		public AbstractApiServerTaskRequestModelValidator(IServerTaskRepository serverTaskRepository)
		{
			this.serverTaskRepository = serverTaskRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiServerTaskRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CompletedTimeRules()
		{
		}

		public virtual void ConcurrencyTagRules()
		{
			this.RuleFor(x => x.ConcurrencyTag).Length(0, 100);
		}

		public virtual void DescriptionRules()
		{
		}

		public virtual void DurationSecondsRules()
		{
		}

		public virtual void EnvironmentIdRules()
		{
			this.RuleFor(x => x.EnvironmentId).Length(0, 50);
		}

		public virtual void ErrorMessageRules()
		{
		}

		public virtual void HasPendingInterruptionsRules()
		{
		}

		public virtual void HasWarningsOrErrorsRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProjectIdRules()
		{
			this.RuleFor(x => x.ProjectId).Length(0, 50);
		}

		public virtual void QueueTimeRules()
		{
		}

		public virtual void ServerNodeIdRules()
		{
			this.RuleFor(x => x.ServerNodeId).Length(0, 250);
		}

		public virtual void StartTimeRules()
		{
		}

		public virtual void StateRules()
		{
			this.RuleFor(x => x.State).Length(0, 50);
		}

		public virtual void TenantIdRules()
		{
			this.RuleFor(x => x.TenantId).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>1dc4fc0e35b4cf1145c86b3ccd23e7ee</Hash>
</Codenesium>*/