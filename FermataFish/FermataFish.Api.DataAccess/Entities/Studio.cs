using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class Studio : AbstractEntity
	{
		public Studio()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			string city,
			int id,
			string name,
			int stateId,
			string website,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id;
			this.Name = name;
			this.StateId = stateId;
			this.Website = website;
			this.Zip = zip;
		}

		[Column("address1")]
		public string Address1 { get; private set; }

		[Column("address2")]
		public string Address2 { get; private set; }

		[Column("city")]
		public string City { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }

		[Column("stateId")]
		public int StateId { get; private set; }

		[Column("website")]
		public string Website { get; private set; }

		[Column("zip")]
		public string Zip { get; private set; }

		[ForeignKey("StateId")]
		public virtual State StateNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>65151da1c0d7c9139c1a50f5ea5c9d2e</Hash>
</Codenesium>*/