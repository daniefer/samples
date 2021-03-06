using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractPersonRefMapper
	{
		public virtual PersonRef MapBOToEF(
			BOPersonRef bo)
		{
			PersonRef efPersonRef = new PersonRef();
			efPersonRef.SetProperties(
				bo.Id,
				bo.PersonAId,
				bo.PersonBId);
			return efPersonRef;
		}

		public virtual BOPersonRef MapEFToBO(
			PersonRef ef)
		{
			var bo = new BOPersonRef();

			bo.SetProperties(
				ef.Id,
				ef.PersonAId,
				ef.PersonBId);
			return bo;
		}

		public virtual List<BOPersonRef> MapEFToBO(
			List<PersonRef> records)
		{
			List<BOPersonRef> response = new List<BOPersonRef>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7f5ce0a85be9badefacc32ab874478d5</Hash>
</Codenesium>*/