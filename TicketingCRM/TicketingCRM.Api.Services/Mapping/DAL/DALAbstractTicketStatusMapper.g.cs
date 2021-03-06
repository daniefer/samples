using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTicketStatusMapper
	{
		public virtual TicketStatus MapBOToEF(
			BOTicketStatus bo)
		{
			TicketStatus efTicketStatus = new TicketStatus();
			efTicketStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efTicketStatus;
		}

		public virtual BOTicketStatus MapEFToBO(
			TicketStatus ef)
		{
			var bo = new BOTicketStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOTicketStatus> MapEFToBO(
			List<TicketStatus> records)
		{
			List<BOTicketStatus> response = new List<BOTicketStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>05f9f675890e1601fc10c7d017060cf5</Hash>
</Codenesium>*/