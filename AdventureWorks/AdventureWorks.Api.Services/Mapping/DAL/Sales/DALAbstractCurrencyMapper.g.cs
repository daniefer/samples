using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractCurrencyMapper
	{
		public virtual Currency MapBOToEF(
			BOCurrency bo)
		{
			Currency efCurrency = new Currency();
			efCurrency.SetProperties(
				bo.CurrencyCode,
				bo.ModifiedDate,
				bo.Name);
			return efCurrency;
		}

		public virtual BOCurrency MapEFToBO(
			Currency ef)
		{
			var bo = new BOCurrency();

			bo.SetProperties(
				ef.CurrencyCode,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOCurrency> MapEFToBO(
			List<Currency> records)
		{
			List<BOCurrency> response = new List<BOCurrency>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea6a96acb1a4ddad4c71899cf9a2c976</Hash>
</Codenesium>*/