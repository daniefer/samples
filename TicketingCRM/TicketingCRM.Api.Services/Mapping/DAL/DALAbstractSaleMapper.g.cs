using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractSaleMapper
	{
		public virtual Sale MapBOToEF(
			BOSale bo)
		{
			Sale efSale = new Sale();
			efSale.SetProperties(
				bo.Id,
				bo.IpAddress,
				bo.Notes,
				bo.SaleDate,
				bo.TransactionId);
			return efSale;
		}

		public virtual BOSale MapEFToBO(
			Sale ef)
		{
			var bo = new BOSale();

			bo.SetProperties(
				ef.Id,
				ef.IpAddress,
				ef.Notes,
				ef.SaleDate,
				ef.TransactionId);
			return bo;
		}

		public virtual List<BOSale> MapEFToBO(
			List<Sale> records)
		{
			List<BOSale> response = new List<BOSale>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7e8b77ade16ec10e4a3d4883899dc14d</Hash>
</Codenesium>*/