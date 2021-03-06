using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesReasonResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int salesReasonID,
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.SalesReasonID = salesReasonID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ReasonType { get; private set; }

		[JsonProperty]
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>26a390ac3afebe301a6912b121b0be0d</Hash>
</Codenesium>*/