using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IVariableSetService
	{
		Task<CreateResponse<ApiVariableSetResponseModel>> Create(
			ApiVariableSetRequestModel model);

		Task<UpdateResponse<ApiVariableSetResponseModel>> Update(string id,
		                                                          ApiVariableSetRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiVariableSetResponseModel> Get(string id);

		Task<List<ApiVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8c6542fc9d67aaf2964d31b5c8db8aea</Hash>
</Codenesium>*/