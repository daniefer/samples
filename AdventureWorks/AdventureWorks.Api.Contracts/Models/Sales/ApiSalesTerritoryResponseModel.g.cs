using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTerritoryResponseModel: AbstractApiResponseModel
	{
		public ApiSalesTerritoryResponseModel() : base()
		{}

		public void SetProperties(
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			string @group,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD,
			int territoryID)
		{
			this.CostLastYear = costLastYear.ToDecimal();
			this.CostYTD = costYTD.ToDecimal();
			this.CountryRegionCode = countryRegionCode;
			this.@Group = @group;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.TerritoryID = territoryID.ToInt();
		}

		public decimal CostLastYear { get; set; }
		public decimal CostYTD { get; set; }
		public string CountryRegionCode { get; set; }
		public string @Group { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesLastYear { get; set; }
		public decimal SalesYTD { get; set; }
		public int TerritoryID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCostLastYearValue { get; set; } = true;

		public bool ShouldSerializeCostLastYear()
		{
			return this.ShouldSerializeCostLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostYTDValue { get; set; } = true;

		public bool ShouldSerializeCostYTD()
		{
			return this.ShouldSerializeCostYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return this.ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGroupValue { get; set; } = true;

		public bool ShouldSerializeGroup()
		{
			return this.ShouldSerializeGroupValue;
		}

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
		public bool ShouldSerializeSalesLastYearValue { get; set; } = true;

		public bool ShouldSerializeSalesLastYear()
		{
			return this.ShouldSerializeSalesLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesYTDValue { get; set; } = true;

		public bool ShouldSerializeSalesYTD()
		{
			return this.ShouldSerializeSalesYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCostLastYearValue = false;
			this.ShouldSerializeCostYTDValue = false;
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeGroupValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>627364f169e75afae0c171141f35a55f</Hash>
</Codenesium>*/