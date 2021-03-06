using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IWorkerService
	{
		Task<CreateResponse<ApiWorkerResponseModel>> Create(
			ApiWorkerRequestModel model);

		Task<UpdateResponse<ApiWorkerResponseModel>> Update(string id,
		                                                     ApiWorkerRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiWorkerResponseModel> Get(string id);

		Task<List<ApiWorkerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiWorkerResponseModel> ByName(string name);

		Task<List<ApiWorkerResponseModel>> ByMachinePolicyId(string machinePolicyId);
	}
}

/*<Codenesium>
    <Hash>c4853fb28cc559d36698e2e61e0af819</Hash>
</Codenesium>*/