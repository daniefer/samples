using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOffer", Schema="Sales")]
	public partial class EFSpecialOffer: AbstractEntityFrameworkPOCO
	{
		public EFSpecialOffer()
		{}

		public void SetProperties(
			int specialOfferID,
			string description,
			decimal discountPct,
			string type,
			string category,
			DateTime startDate,
			DateTime endDate,
			int minQty,
			Nullable<int> maxQty,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SpecialOfferID = specialOfferID.ToInt();
			this.Description = description.ToString();
			this.DiscountPct = discountPct.ToDecimal();
			this.Type = type.ToString();
			this.Category = category.ToString();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToDateTime();
			this.MinQty = minQty.ToInt();
			this.MaxQty = maxQty.ToNullableInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; set; }

		[Column("Description", TypeName="nvarchar(255)")]
		public string Description { get; set; }

		[Column("DiscountPct", TypeName="smallmoney")]
		public decimal DiscountPct { get; set; }

		[Column("Type", TypeName="nvarchar(50)")]
		public string Type { get; set; }

		[Column("Category", TypeName="nvarchar(50)")]
		public string Category { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public DateTime EndDate { get; set; }

		[Column("MinQty", TypeName="int")]
		public int MinQty { get; set; }

		[Column("MaxQty", TypeName="int")]
		public Nullable<int> MaxQty { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>04002a623724602c63434e2c43c9b7e1</Hash>
</Codenesium>*/