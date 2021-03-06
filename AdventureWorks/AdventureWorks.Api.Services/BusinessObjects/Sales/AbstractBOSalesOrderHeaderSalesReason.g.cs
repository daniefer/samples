using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSalesOrderHeaderSalesReason : AbstractBusinessObject
	{
		public AbstractBOSalesOrderHeaderSalesReason()
			: base()
		{
		}

		public virtual void SetProperties(int salesOrderID,
		                                  DateTime modifiedDate,
		                                  int salesReasonID)
		{
			this.ModifiedDate = modifiedDate;
			this.SalesOrderID = salesOrderID;
			this.SalesReasonID = salesReasonID;
		}

		public DateTime ModifiedDate { get; private set; }

		public int SalesOrderID { get; private set; }

		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b9284a35e952335488a7e9d547ce6a14</Hash>
</Codenesium>*/