using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALFamilyMapper
	{
		Family MapBOToEF(
			BOFamily bo);

		BOFamily MapEFToBO(
			Family efFamily);

		List<BOFamily> MapEFToBO(
			List<Family> records);
	}
}

/*<Codenesium>
    <Hash>1c43b1c14e1e3cafa82bf8093576c3d4</Hash>
</Codenesium>*/