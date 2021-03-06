using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOMachine : AbstractBusinessObject
	{
		public AbstractBOMachine()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string description,
		                                  string jwtKey,
		                                  string lastIpAddress,
		                                  Guid machineGuid,
		                                  string name)
		{
			this.Description = description;
			this.Id = id;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		public string Description { get; private set; }

		public int Id { get; private set; }

		public string JwtKey { get; private set; }

		public string LastIpAddress { get; private set; }

		public Guid MachineGuid { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>53912e62eb106b65a42853906b6e1cb3</Hash>
</Codenesium>*/