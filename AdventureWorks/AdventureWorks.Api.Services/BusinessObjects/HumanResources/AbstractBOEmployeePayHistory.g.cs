using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOEmployeePayHistory : AbstractBusinessObject
	{
		public AbstractBOEmployeePayHistory()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  DateTime modifiedDate,
		                                  int payFrequency,
		                                  decimal rate,
		                                  DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PayFrequency = payFrequency;
			this.Rate = rate;
			this.RateChangeDate = rateChangeDate;
		}

		public int BusinessEntityID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int PayFrequency { get; private set; }

		public decimal Rate { get; private set; }

		public DateTime RateChangeDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e8cbca769c271f1f66867bd3c8a6e46a</Hash>
</Codenesium>*/