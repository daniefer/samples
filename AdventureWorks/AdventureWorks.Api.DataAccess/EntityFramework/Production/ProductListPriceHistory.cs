using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductListPriceHistory", Schema="Production")]
	public partial class ProductListPriceHistory: AbstractEntityFrameworkPOCO
	{
		public ProductListPriceHistory()
		{}

		public void SetProperties(
			int productID,
			Nullable<DateTime> endDate,
			decimal listPrice,
			DateTime modifiedDate,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
		}

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>caca9e3bc3651faac376b77660644f3e</Hash>
</Codenesium>*/