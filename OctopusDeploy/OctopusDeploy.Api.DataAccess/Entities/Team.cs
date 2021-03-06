using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Team", Schema="dbo")]
	public partial class Team : AbstractEntity
	{
		public Team()
		{
		}

		public virtual void SetProperties(
			string environmentIds,
			string id,
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

		[Column("EnvironmentIds")]
		public string EnvironmentIds { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("MemberUserIds")]
		public string MemberUserIds { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Column("ProjectGroupIds")]
		public string ProjectGroupIds { get; private set; }

		[Column("ProjectIds")]
		public string ProjectIds { get; private set; }

		[Column("TenantIds")]
		public string TenantIds { get; private set; }

		[Column("TenantTags")]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2c50af6ab2c3c9ae10c105f51e72d6dc</Hash>
</Codenesium>*/