using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTaxRate", Schema="Sales")]
	public partial class SalesTaxRate : AbstractEntity
	{
		public SalesTaxRate()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int salesTaxRateID,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesTaxRateID = salesTaxRateID;
			this.StateProvinceID = stateProvinceID;
			this.TaxRate = taxRate;
			this.TaxType = taxType;
		}

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesTaxRateID")]
		public int SalesTaxRateID { get; private set; }

		[Column("StateProvinceID")]
		public int StateProvinceID { get; private set; }

		[Column("TaxRate")]
		public decimal TaxRate { get; private set; }

		[Column("TaxType")]
		public int TaxType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8631c56daa035ea2b5faa878e991d977</Hash>
</Codenesium>*/