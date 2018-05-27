using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModel", Schema="Production")]
	public partial class ProductModel: AbstractEntityFrameworkDTO
	{
		public ProductModel()
		{}

		public void SetProperties(
			int productModelID,
			string catalogDescription,
			string instructions,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductModelID = productModelID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("CatalogDescription", TypeName="xml(-1)")]
		public string CatalogDescription { get; set; }

		[Column("Instructions", TypeName="xml(-1)")]
		public string Instructions { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>d3161695beffd5aa5c9eeef192e8e125</Hash>
</Codenesium>*/