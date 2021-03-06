using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractClientMapper
	{
		public virtual Client MapBOToEF(
			BOClient bo)
		{
			Client efClient = new Client();
			efClient.SetProperties(
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Notes,
				bo.Phone);
			return efClient;
		}

		public virtual BOClient MapEFToBO(
			Client ef)
		{
			var bo = new BOClient();

			bo.SetProperties(
				ef.Id,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Notes,
				ef.Phone);
			return bo;
		}

		public virtual List<BOClient> MapEFToBO(
			List<Client> records)
		{
			List<BOClient> response = new List<BOClient>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe59e48299ef7d4fa2c84e3b2445c93f</Hash>
</Codenesium>*/