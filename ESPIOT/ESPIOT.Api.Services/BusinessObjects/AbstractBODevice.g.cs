using Codenesium.DataConversionExtensions;
using System;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractBODevice : AbstractBusinessObject
	{
		public AbstractBODevice()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  Guid publicId)
		{
			this.Id = id;
			this.Name = name;
			this.PublicId = publicId;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0ff05b171ccdde8cb402a40f0abefe43</Hash>
</Codenesium>*/