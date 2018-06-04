using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTaxRateResponseModel: AbstractApiResponseModel
	{
		public ApiSalesTaxRateResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int salesTaxRateID,
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

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesTaxRateIDValue { get; set; } = true;

		public bool ShouldSerializeSalesTaxRateID()
		{
			return this.ShouldSerializeSalesTaxRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxRateValue { get; set; } = true;

		public bool ShouldSerializeTaxRate()
		{
			return this.ShouldSerializeTaxRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxTypeValue { get; set; } = true;

		public bool ShouldSerializeTaxType()
		{
			return this.ShouldSerializeTaxTypeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesTaxRateIDValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializeTaxRateValue = false;
			this.ShouldSerializeTaxTypeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e084f70aebfec9264c058e6be53cdd9d</Hash>
</Codenesium>*/