using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractTableMapper
	{
		public virtual Table MapBOToEF(
			BOTable bo)
		{
			Table efTable = new Table();
			efTable.SetProperties(
				bo.Id,
				bo.Name);
			return efTable;
		}

		public virtual BOTable MapEFToBO(
			Table ef)
		{
			var bo = new BOTable();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOTable> MapEFToBO(
			List<Table> records)
		{
			List<BOTable> response = new List<BOTable>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6f44a23eec20f11062c76e923e2e6659</Hash>
</Codenesium>*/