using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOPurchaseOrderHeader : AbstractBusinessObject
	{
		public AbstractBOPurchaseOrderHeader()
			: base()
		{
		}

		public virtual void SetProperties(int purchaseOrderID,
		                                  int employeeID,
		                                  decimal freight,
		                                  DateTime modifiedDate,
		                                  DateTime orderDate,
		                                  int revisionNumber,
		                                  DateTime? shipDate,
		                                  int shipMethodID,
		                                  int status,
		                                  decimal subTotal,
		                                  decimal taxAmt,
		                                  decimal totalDue,
		                                  int vendorID)
		{
			this.EmployeeID = employeeID;
			this.Freight = freight;
			this.ModifiedDate = modifiedDate;
			this.OrderDate = orderDate;
			this.PurchaseOrderID = purchaseOrderID;
			this.RevisionNumber = revisionNumber;
			this.ShipDate = shipDate;
			this.ShipMethodID = shipMethodID;
			this.Status = status;
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.TotalDue = totalDue;
			this.VendorID = vendorID;
		}

		public int EmployeeID { get; private set; }

		public decimal Freight { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public DateTime OrderDate { get; private set; }

		public int PurchaseOrderID { get; private set; }

		public int RevisionNumber { get; private set; }

		public DateTime? ShipDate { get; private set; }

		public int ShipMethodID { get; private set; }

		public int Status { get; private set; }

		public decimal SubTotal { get; private set; }

		public decimal TaxAmt { get; private set; }

		public decimal TotalDue { get; private set; }

		public int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>32aa3cdeba355b83940b02299f578e08</Hash>
</Codenesium>*/