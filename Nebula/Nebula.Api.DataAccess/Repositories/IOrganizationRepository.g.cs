using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		Task<Organization> Create(Organization item);

		Task Update(Organization item);

		Task Delete(int id);

		Task<Organization> Get(int id);

		Task<List<Organization>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Team>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>402e491a5a75a06fc580006fb30259e2</Hash>
</Codenesium>*/