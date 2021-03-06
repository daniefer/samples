using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALDestinationMapper
	{
		Destination MapBOToEF(
			BODestination bo);

		BODestination MapEFToBO(
			Destination efDestination);

		List<BODestination> MapEFToBO(
			List<Destination> records);
	}
}

/*<Codenesium>
    <Hash>7974bdfad34072d491e2f3eb741d745a</Hash>
</Codenesium>*/