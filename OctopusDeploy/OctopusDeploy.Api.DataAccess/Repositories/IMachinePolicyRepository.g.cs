using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IMachinePolicyRepository
	{
		Task<MachinePolicy> Create(MachinePolicy item);

		Task Update(MachinePolicy item);

		Task Delete(string id);

		Task<MachinePolicy> Get(string id);

		Task<List<MachinePolicy>> All(int limit = int.MaxValue, int offset = 0);

		Task<MachinePolicy> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>bd5521445bcb0286a5ee8a133922df72</Hash>
</Codenesium>*/