using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("MachinePolicy", Schema="dbo")]
	public partial class MachinePolicy : AbstractEntity
	{
		public MachinePolicy()
		{
		}

		public virtual void SetProperties(
			string id,
			bool isDefault,
			string jSON,
			string name)
		{
			this.Id = id;
			this.IsDefault = isDefault;
			this.JSON = jSON;
			this.Name = name;
		}

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IsDefault")]
		public bool IsDefault { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>02fd67d7e744dffde8912c2aa42109e4</Hash>
</Codenesium>*/