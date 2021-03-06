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
	public abstract class AbstractApiDeploymentRequestModelValidator : AbstractValidator<ApiDeploymentRequestModel>
	{
		private string existingRecordId;

		private IDeploymentRepository deploymentRepository;

		public AbstractApiDeploymentRequestModelValidator(IDeploymentRepository deploymentRepository)
		{
			this.deploymentRepository = deploymentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeploymentRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChannelIdRules()
		{
			this.RuleFor(x => x.ChannelId).Length(0, 50);
		}

		public virtual void CreatedRules()
		{
		}

		public virtual void DeployedByRules()
		{
			this.RuleFor(x => x.DeployedBy).Length(0, 200);
		}

		public virtual void DeployedToMachineIdsRules()
		{
		}

		public virtual void EnvironmentIdRules()
		{
			this.RuleFor(x => x.EnvironmentId).Length(0, 50);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void ProjectGroupIdRules()
		{
			this.RuleFor(x => x.ProjectGroupId).Length(0, 50);
		}

		public virtual void ProjectIdRules()
		{
			this.RuleFor(x => x.ProjectId).Length(0, 50);
		}

		public virtual void ReleaseIdRules()
		{
			this.RuleFor(x => x.ReleaseId).Length(0, 50);
		}

		public virtual void TaskIdRules()
		{
			this.RuleFor(x => x.TaskId).Length(0, 50);
		}

		public virtual void TenantIdRules()
		{
			this.RuleFor(x => x.TenantId).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>c011078a78731db92ee087b0acba0be1</Hash>
</Codenesium>*/