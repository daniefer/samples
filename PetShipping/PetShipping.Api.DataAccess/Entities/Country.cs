using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Country", Schema="dbo")]
	public partial class Country : AbstractEntity
	{
		public Country()
		{
		}

		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>001b23fad6fde4c897869075e0ce7842</Hash>
</Codenesium>*/