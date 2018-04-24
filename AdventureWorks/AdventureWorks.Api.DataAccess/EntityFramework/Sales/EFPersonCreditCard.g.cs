using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class EFPersonCreditCard: AbstractEntityFrameworkPOCO
	{
		public EFPersonCreditCard()
		{}

		public void SetProperties(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }

		[ForeignKey("CreditCardID")]
		public virtual EFCreditCard CreditCard { get; set; }
	}
}

/*<Codenesium>
    <Hash>28ef0e103a4e869ecf89bc390f9542e5</Hash>
</Codenesium>*/