using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBODeploymentHistory : AbstractBusinessObject
	{
		public AbstractBODeploymentHistory()
			: base()
		{
		}

		public virtual void SetProperties(string deploymentId,
		                                  string channelId,
		                                  string channelName,
		                                  DateTimeOffset? completedTime,
		                                  DateTimeOffset created,
		                                  string deployedBy,
		                                  string deploymentName,
		                                  int? durationSeconds,
		                                  string environmentId,
		                                  string environmentName,
		                                  string projectId,
		                                  string projectName,
		                                  string projectSlug,
		                                  DateTimeOffset queueTime,
		                                  string releaseId,
		                                  string releaseVersion,
		                                  DateTimeOffset? startTime,
		                                  string taskId,
		                                  string taskState,
		                                  string tenantId,
		                                  string tenantName)
		{
			this.ChannelId = channelId;
			this.ChannelName = channelName;
			this.CompletedTime = completedTime;
			this.Created = created;
			this.DeployedBy = deployedBy;
			this.DeploymentId = deploymentId;
			this.DeploymentName = deploymentName;
			this.DurationSeconds = durationSeconds;
			this.EnvironmentId = environmentId;
			this.EnvironmentName = environmentName;
			this.ProjectId = projectId;
			this.ProjectName = projectName;
			this.ProjectSlug = projectSlug;
			this.QueueTime = queueTime;
			this.ReleaseId = releaseId;
			this.ReleaseVersion = releaseVersion;
			this.StartTime = startTime;
			this.TaskId = taskId;
			this.TaskState = taskState;
			this.TenantId = tenantId;
			this.TenantName = tenantName;
		}

		public string ChannelId { get; private set; }

		public string ChannelName { get; private set; }

		public DateTimeOffset? CompletedTime { get; private set; }

		public DateTimeOffset Created { get; private set; }

		public string DeployedBy { get; private set; }

		public string DeploymentId { get; private set; }

		public string DeploymentName { get; private set; }

		public int? DurationSeconds { get; private set; }

		public string EnvironmentId { get; private set; }

		public string EnvironmentName { get; private set; }

		public string ProjectId { get; private set; }

		public string ProjectName { get; private set; }

		public string ProjectSlug { get; private set; }

		public DateTimeOffset QueueTime { get; private set; }

		public string ReleaseId { get; private set; }

		public string ReleaseVersion { get; private set; }

		public DateTimeOffset? StartTime { get; private set; }

		public string TaskId { get; private set; }

		public string TaskState { get; private set; }

		public string TenantId { get; private set; }

		public string TenantName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>03a298fcf66417b9a0b2e30781251256</Hash>
</Codenesium>*/