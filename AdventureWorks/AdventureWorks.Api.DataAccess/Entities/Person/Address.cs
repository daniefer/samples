using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Address", Schema="Person")]
	public partial class Address : AbstractEntity
	{
		public Address()
		{
		}

		public virtual void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			int stateProvinceID)
		{
			this.AddressID = addressID;
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate;
			this.PostalCode = postalCode;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("AddressID")]
		public int AddressID { get; private set; }

		[Column("AddressLine1")]
		public string AddressLine1 { get; private set; }

		[Column("AddressLine2")]
		public string AddressLine2 { get; private set; }

		[Column("City")]
		public string City { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PostalCode")]
		public string PostalCode { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("StateProvinceID")]
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2d08fd8cfa8aa4125766c3f84a6f3f0a</Hash>
</Codenesium>*/