using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOChannel : AbstractBusinessObject
	{
		public AbstractBOChannel()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  byte[] dataVersion,
		                                  string jSON,
		                                  string lifecycleId,
		                                  string name,
		                                  string projectId,
		                                  string tenantTags)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.LifecycleId = lifecycleId;
			this.Name = name;
			this.ProjectId = projectId;
			this.TenantTags = tenantTags;
		}

		public byte[] DataVersion { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string LifecycleId { get; private set; }

		public string Name { get; private set; }

		public string ProjectId { get; private set; }

		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>768a5463e32da30bc813d0d02d9dd686</Hash>
</Codenesium>*/