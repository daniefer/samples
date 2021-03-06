using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPersonCreditCardMapper
	{
		public virtual PersonCreditCard MapBOToEF(
			BOPersonCreditCard bo)
		{
			PersonCreditCard efPersonCreditCard = new PersonCreditCard();
			efPersonCreditCard.SetProperties(
				bo.BusinessEntityID,
				bo.CreditCardID,
				bo.ModifiedDate);
			return efPersonCreditCard;
		}

		public virtual BOPersonCreditCard MapEFToBO(
			PersonCreditCard ef)
		{
			var bo = new BOPersonCreditCard();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.CreditCardID,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOPersonCreditCard> MapEFToBO(
			List<PersonCreditCard> records)
		{
			List<BOPersonCreditCard> response = new List<BOPersonCreditCard>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fdb78c70b75355f554210372d4756db3</Hash>
</Codenesium>*/