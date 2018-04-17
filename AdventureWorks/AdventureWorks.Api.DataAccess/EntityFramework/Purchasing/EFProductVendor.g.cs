using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class EFProductVendor
	{
		public EFProductVendor()
		{}

		public void SetProperties(
			int productID,
			int businessEntityID,
			int averageLeadTime,
			decimal standardPrice,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int minOrderQty,
			int maxOrderQty,
			Nullable<int> onOrderQty,
			string unitMeasureCode,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AverageLeadTime = averageLeadTime.ToInt();
			this.StandardPrice = standardPrice.ToDecimal();
			this.LastReceiptCost = lastReceiptCost.ToNullableDecimal();
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MinOrderQty = minOrderQty.ToInt();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.UnitMeasureCode = unitMeasureCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("AverageLeadTime", TypeName="int")]
		public int AverageLeadTime { get; set; }

		[Column("StandardPrice", TypeName="money")]
		public decimal StandardPrice { get; set; }

		[Column("LastReceiptCost", TypeName="money")]
		public Nullable<decimal> LastReceiptCost { get; set; }

		[Column("LastReceiptDate", TypeName="datetime")]
		public Nullable<DateTime> LastReceiptDate { get; set; }

		[Column("MinOrderQty", TypeName="int")]
		public int MinOrderQty { get; set; }

		[Column("MaxOrderQty", TypeName="int")]
		public int MaxOrderQty { get; set; }

		[Column("OnOrderQty", TypeName="int")]
		public Nullable<int> OnOrderQty { get; set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFVendor Vendor { get; set; }

		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure { get; set; }
	}
}

/*<Codenesium>
    <Hash>1b0e65205d6c749038a8f1efb8a514f2</Hash>
</Codenesium>*/