using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOSalesTaxRate: AbstractBusinessObject
	{
		public BOSalesTaxRate() : base()
		{}

		public void SetProperties(int salesTaxRateID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          int stateProvinceID,
		                          decimal taxRate,
		                          int taxType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.TaxType = taxType.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public int SalesTaxRateID { get; private set; }
		public int StateProvinceID { get; private set; }
		public decimal TaxRate { get; private set; }
		public int TaxType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0701337918aeca3b74aad88c94d1ccc5</Hash>
</Codenesium>*/