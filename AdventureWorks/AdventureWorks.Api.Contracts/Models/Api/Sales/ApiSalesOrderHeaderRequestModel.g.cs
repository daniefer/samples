using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderRequestModel : AbstractApiRequestModel
	{
		public ApiSalesOrderHeaderRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string accountNumber,
			int billToAddressID,
			string comment,
			string creditCardApprovalCode,
			int? creditCardID,
			int? currencyRateID,
			int customerID,
			DateTime dueDate,
			decimal freight,
			DateTime modifiedDate,
			bool onlineOrderFlag,
			DateTime orderDate,
			string purchaseOrderNumber,
			int revisionNumber,
			Guid rowguid,
			string salesOrderNumber,
			int? salesPersonID,
			DateTime? shipDate,
			int shipMethodID,
			int shipToAddressID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			int? territoryID,
			decimal totalDue)
		{
			this.AccountNumber = accountNumber;
			this.BillToAddressID = billToAddressID;
			this.Comment = comment;
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.CreditCardID = creditCardID;
			this.CurrencyRateID = currencyRateID;
			this.CustomerID = customerID;
			this.DueDate = dueDate;
			this.Freight = freight;
			this.ModifiedDate = modifiedDate;
			this.OnlineOrderFlag = onlineOrderFlag;
			this.OrderDate = orderDate;
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.RevisionNumber = revisionNumber;
			this.Rowguid = rowguid;
			this.SalesOrderNumber = salesOrderNumber;
			this.SalesPersonID = salesPersonID;
			this.ShipDate = shipDate;
			this.ShipMethodID = shipMethodID;
			this.ShipToAddressID = shipToAddressID;
			this.Status = status;
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.TerritoryID = territoryID;
			this.TotalDue = totalDue;
		}

		[JsonProperty]
		public string AccountNumber { get; private set; }

		[Required]
		[JsonProperty]
		public int BillToAddressID { get; private set; }

		[JsonProperty]
		public string Comment { get; private set; }

		[JsonProperty]
		public string CreditCardApprovalCode { get; private set; }

		[JsonProperty]
		public int? CreditCardID { get; private set; }

		[JsonProperty]
		public int? CurrencyRateID { get; private set; }

		[Required]
		[JsonProperty]
		public int CustomerID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[Required]
		[JsonProperty]
		public decimal Freight { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public bool OnlineOrderFlag { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime OrderDate { get; private set; }

		[JsonProperty]
		public string PurchaseOrderNumber { get; private set; }

		[Required]
		[JsonProperty]
		public int RevisionNumber { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public string SalesOrderNumber { get; private set; }

		[JsonProperty]
		public int? SalesPersonID { get; private set; }

		[JsonProperty]
		public DateTime? ShipDate { get; private set; }

		[Required]
		[JsonProperty]
		public int ShipMethodID { get; private set; }

		[Required]
		[JsonProperty]
		public int ShipToAddressID { get; private set; }

		[Required]
		[JsonProperty]
		public int Status { get; private set; }

		[Required]
		[JsonProperty]
		public decimal SubTotal { get; private set; }

		[Required]
		[JsonProperty]
		public decimal TaxAmt { get; private set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[Required]
		[JsonProperty]
		public decimal TotalDue { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2aa510e4c9dc3fde4c472b865115fbd</Hash>
</Codenesium>*/