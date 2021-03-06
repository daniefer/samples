using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOTimestampCheck : AbstractBusinessObject
	{
		public AbstractBOTimestampCheck()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  byte[] timestamp)
		{
			this.Id = id;
			this.Name = name;
			this.Timestamp = timestamp;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4239182dd96af499291ba294be56b9d4</Hash>
</Codenesium>*/