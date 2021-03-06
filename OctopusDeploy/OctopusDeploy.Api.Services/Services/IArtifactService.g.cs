using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IArtifactService
	{
		Task<CreateResponse<ApiArtifactResponseModel>> Create(
			ApiArtifactRequestModel model);

		Task<UpdateResponse<ApiArtifactResponseModel>> Update(string id,
		                                                       ApiArtifactRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiArtifactResponseModel> Get(string id);

		Task<List<ApiArtifactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiArtifactResponseModel>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>6a7760b0fd62183e2cdd75f18d00e745</Hash>
</Codenesium>*/