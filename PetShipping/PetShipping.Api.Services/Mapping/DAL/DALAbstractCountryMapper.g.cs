using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractCountryMapper
	{
		public virtual Country MapBOToEF(
			BOCountry bo)
		{
			Country efCountry = new Country();
			efCountry.SetProperties(
				bo.Id,
				bo.Name);
			return efCountry;
		}

		public virtual BOCountry MapEFToBO(
			Country ef)
		{
			var bo = new BOCountry();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOCountry> MapEFToBO(
			List<Country> records)
		{
			List<BOCountry> response = new List<BOCountry>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c4407e7ea270391b21e7bf9b073283ad</Hash>
</Codenesium>*/