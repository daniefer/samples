using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ActionTemplate", Schema="dbo")]
	public partial class ActionTemplate : AbstractEntity
	{
		public ActionTemplate()
		{
		}

		public virtual void SetProperties(
			string actionType,
			string communityActionTemplateId,
			string id,
			string jSON,
			string name,
			int version)
		{
			this.ActionType = actionType;
			this.CommunityActionTemplateId = communityActionTemplateId;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.Version = version;
		}

		[Column("ActionType")]
		public string ActionType { get; private set; }

		[Column("CommunityActionTemplateId")]
		public string CommunityActionTemplateId { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Column("Version")]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>10b74d18d67e567180ddcf30bf564fc5</Hash>
</Codenesium>*/