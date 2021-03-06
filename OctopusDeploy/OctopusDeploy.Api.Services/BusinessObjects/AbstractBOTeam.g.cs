using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOTeam : AbstractBusinessObject
	{
		public AbstractBOTeam()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string environmentIds,
		                                  string jSON,
		                                  string memberUserIds,
		                                  string name,
		                                  string projectGroupIds,
		                                  string projectIds,
		                                  string tenantIds,
		                                  string tenantTags)
		{
			this.EnvironmentIds = environmentIds;
			this.Id = id;
			this.JSON = jSON;
			this.MemberUserIds = memberUserIds;
			this.Name = name;
			this.ProjectGroupIds = projectGroupIds;
			this.ProjectIds = projectIds;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
		}

		public string EnvironmentIds { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string MemberUserIds { get; private set; }

		public string Name { get; private set; }

		public string ProjectGroupIds { get; private set; }

		public string ProjectIds { get; private set; }

		public string TenantIds { get; private set; }

		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>626621dfd47e45f0ba21b2d02902559d</Hash>
</Codenesium>*/