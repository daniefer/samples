using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPersonPhoneMapper
	{
		public virtual PersonPhone MapBOToEF(
			BOPersonPhone bo)
		{
			PersonPhone efPersonPhone = new PersonPhone();
			efPersonPhone.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.PhoneNumber,
				bo.PhoneNumberTypeID);
			return efPersonPhone;
		}

		public virtual BOPersonPhone MapEFToBO(
			PersonPhone ef)
		{
			var bo = new BOPersonPhone();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PhoneNumber,
				ef.PhoneNumberTypeID);
			return bo;
		}

		public virtual List<BOPersonPhone> MapEFToBO(
			List<PersonPhone> records)
		{
			List<BOPersonPhone> response = new List<BOPersonPhone>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>815cbd5c9840862d2207996d88c63e2d</Hash>
</Codenesium>*/