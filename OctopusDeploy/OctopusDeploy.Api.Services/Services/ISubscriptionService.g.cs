using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface ISubscriptionService
	{
		Task<CreateResponse<ApiSubscriptionResponseModel>> Create(
			ApiSubscriptionRequestModel model);

		Task<UpdateResponse<ApiSubscriptionResponseModel>> Update(string id,
		                                                           ApiSubscriptionRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiSubscriptionResponseModel> Get(string id);

		Task<List<ApiSubscriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSubscriptionResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>ee7a915d738c265eb38e14ae7cee77e5</Hash>
</Codenesium>*/