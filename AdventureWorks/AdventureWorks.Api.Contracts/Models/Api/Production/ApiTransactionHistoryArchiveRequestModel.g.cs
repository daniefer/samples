using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiTransactionHistoryArchiveRequestModel : AbstractApiRequestModel
	{
		public ApiTransactionHistoryArchiveRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal actualCost,
			DateTime modifiedDate,
			int productID,
			int quantity,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			string transactionType)
		{
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ReferenceOrderID = referenceOrderID;
			this.ReferenceOrderLineID = referenceOrderLineID;
			this.TransactionDate = transactionDate;
			this.TransactionType = transactionType;
		}

		[Required]
		[JsonProperty]
		public decimal ActualCost { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public int Quantity { get; private set; }

		[Required]
		[JsonProperty]
		public int ReferenceOrderID { get; private set; }

		[Required]
		[JsonProperty]
		public int ReferenceOrderLineID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime TransactionDate { get; private set; }

		[Required]
		[JsonProperty]
		public string TransactionType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3db109ebb658cb90fa7ae21c6da2a5cf</Hash>
</Codenesium>*/