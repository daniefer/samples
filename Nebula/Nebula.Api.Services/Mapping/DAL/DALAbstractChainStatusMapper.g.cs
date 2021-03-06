using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractChainStatusMapper
	{
		public virtual ChainStatus MapBOToEF(
			BOChainStatus bo)
		{
			ChainStatus efChainStatus = new ChainStatus();
			efChainStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efChainStatus;
		}

		public virtual BOChainStatus MapEFToBO(
			ChainStatus ef)
		{
			var bo = new BOChainStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOChainStatus> MapEFToBO(
			List<ChainStatus> records)
		{
			List<BOChainStatus> response = new List<BOChainStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cfd8cb91fe4178ea1214608409cd8ccf</Hash>
</Codenesium>*/