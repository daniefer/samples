using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductListPriceHistoryResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int productID,
			DateTime? endDate,
			decimal listPrice,
			DateTime modifiedDate,
			DateTime startDate)
		{
			this.ProductID = productID;
			this.EndDate = endDate;
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate;
			this.StartDate = startDate;
		}

		[Required]
		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public decimal ListPrice { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cdb89ad34982daed839021ea78a45fc6</Hash>
</Codenesium>*/