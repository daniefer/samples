using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOEmployee : AbstractBusinessObject
	{
		public AbstractBOEmployee()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string firstName,
		                                  bool isSalesPerson,
		                                  bool isShipper,
		                                  string lastName)
		{
			this.FirstName = firstName;
			this.Id = id;
			this.IsSalesPerson = isSalesPerson;
			this.IsShipper = isShipper;
			this.LastName = lastName;
		}

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public bool IsSalesPerson { get; private set; }

		public bool IsShipper { get; private set; }

		public string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fa00b6573a788bb1aefb5a7aed79d807</Hash>
</Codenesium>*/