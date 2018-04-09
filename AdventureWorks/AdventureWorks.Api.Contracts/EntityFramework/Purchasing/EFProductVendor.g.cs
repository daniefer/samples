using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class EFProductVendor
	{
		public EFProductVendor()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("AverageLeadTime", TypeName="int")]
		public int AverageLeadTime {get; set;}

		[Column("StandardPrice", TypeName="money")]
		public decimal StandardPrice {get; set;}

		[Column("LastReceiptCost", TypeName="money")]
		public Nullable<decimal> LastReceiptCost {get; set;}

		[Column("LastReceiptDate", TypeName="datetime")]
		public Nullable<DateTime> LastReceiptDate {get; set;}

		[Column("MinOrderQty", TypeName="int")]
		public int MinOrderQty {get; set;}

		[Column("MaxOrderQty", TypeName="int")]
		public int MaxOrderQty {get; set;}

		[Column("OnOrderQty", TypeName="int")]
		public Nullable<int> OnOrderQty {get; set;}

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
		[ForeignKey("BusinessEntityID")]
		public virtual EFVendor Vendor { get; set; }
		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure { get; set; }
	}
}

/*<Codenesium>
    <Hash>c00e9848a8d6a581a7995b1f3a3f4551</Hash>
</Codenesium>*/