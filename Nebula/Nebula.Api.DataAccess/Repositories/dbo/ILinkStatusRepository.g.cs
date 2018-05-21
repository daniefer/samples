using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		Task<POCOLinkStatus> Create(ApiLinkStatusModel model);

		Task Update(int id,
		            ApiLinkStatusModel model);

		Task Delete(int id);

		Task<POCOLinkStatus> Get(int id);

		Task<List<POCOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOLinkStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>3ec27a3684100342457c1ff3140ed67b</Hash>
</Codenesium>*/