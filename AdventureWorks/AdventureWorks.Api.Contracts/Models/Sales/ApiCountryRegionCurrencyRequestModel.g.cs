using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCountryRegionCurrencyRequestModel: AbstractApiRequestModel
	{
		public ApiCountryRegionCurrencyRequestModel() : base()
		{}

		public void SetProperties(
			string currencyCode,
			DateTime modifiedDate)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string currencyCode;

		[Required]
		public string CurrencyCode
		{
			get
			{
				return this.currencyCode;
			}

			set
			{
				this.currencyCode = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ac4870f65514c4afa38d7e70e0908c95</Hash>
</Codenesium>*/