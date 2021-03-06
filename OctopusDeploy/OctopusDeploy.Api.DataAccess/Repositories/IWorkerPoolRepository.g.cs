using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IWorkerPoolRepository
	{
		Task<WorkerPool> Create(WorkerPool item);

		Task Update(WorkerPool item);

		Task Delete(string id);

		Task<WorkerPool> Get(string id);

		Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset = 0);

		Task<WorkerPool> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>4ebdbbe3380f36a1988f6d49c87e550c</Hash>
</Codenesium>*/