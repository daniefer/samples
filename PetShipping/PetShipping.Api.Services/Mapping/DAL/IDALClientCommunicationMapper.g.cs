using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALClientCommunicationMapper
	{
		ClientCommunication MapBOToEF(
			BOClientCommunication bo);

		BOClientCommunication MapEFToBO(
			ClientCommunication efClientCommunication);

		List<BOClientCommunication> MapEFToBO(
			List<ClientCommunication> records);
	}
}

/*<Codenesium>
    <Hash>7fc91db3d3ee96dcb0f26e020ccd7d03</Hash>
</Codenesium>*/