using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ProjectGroup", Schema="dbo")]
	public partial class ProjectGroup : AbstractEntity
	{
		public ProjectGroup()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string id,
			string jSON,
			string name)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[Column("DataVersion")]
		public byte[] DataVersion { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>232790fefc1504981fc645c72ec8d417</Hash>
</Codenesium>*/