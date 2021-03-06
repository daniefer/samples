using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractPersonMapper
	{
		public virtual Person MapBOToEF(
			BOPerson bo)
		{
			Person efPerson = new Person();
			efPerson.SetProperties(
				bo.PersonId,
				bo.PersonName);
			return efPerson;
		}

		public virtual BOPerson MapEFToBO(
			Person ef)
		{
			var bo = new BOPerson();

			bo.SetProperties(
				ef.PersonId,
				ef.PersonName);
			return bo;
		}

		public virtual List<BOPerson> MapEFToBO(
			List<Person> records)
		{
			List<BOPerson> response = new List<BOPerson>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f3213b1cbc741fa518794d0841289686</Hash>
</Codenesium>*/