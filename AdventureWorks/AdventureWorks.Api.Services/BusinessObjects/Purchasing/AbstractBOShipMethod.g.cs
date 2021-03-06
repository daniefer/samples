using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOShipMethod : AbstractBusinessObject
	{
		public AbstractBOShipMethod()
			: base()
		{
		}

		public virtual void SetProperties(int shipMethodID,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  Guid rowguid,
		                                  decimal shipBase,
		                                  decimal shipRate)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ShipBase = shipBase;
			this.ShipMethodID = shipMethodID;
			this.ShipRate = shipRate;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public Guid Rowguid { get; private set; }

		public decimal ShipBase { get; private set; }

		public int ShipMethodID { get; private set; }

		public decimal ShipRate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>15906f3ec319a6592876f50bb8815042</Hash>
</Codenesium>*/