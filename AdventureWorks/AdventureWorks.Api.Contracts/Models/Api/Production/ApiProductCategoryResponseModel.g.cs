using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductCategoryResponseModel: AbstractApiResponseModel
	{
		public ApiProductCategoryResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int ProductCategoryID { get; private set; }
		public Guid Rowguid { get; private set; }

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
		public bool ShouldSerializeProductCategoryIDValue { get; set; } = true;

		public bool ShouldSerializeProductCategoryID()
		{
			return this.ShouldSerializeProductCategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeProductCategoryIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>75060d9dc3dedf6b54a047d5eb6cbffc</Hash>
</Codenesium>*/