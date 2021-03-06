using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface ICommentsService
	{
		Task<CreateResponse<ApiCommentsResponseModel>> Create(
			ApiCommentsRequestModel model);

		Task<UpdateResponse<ApiCommentsResponseModel>> Update(int id,
		                                                       ApiCommentsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCommentsResponseModel> Get(int id);

		Task<List<ApiCommentsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>694a2f3f091c93ece88fe2511564fa61</Hash>
</Codenesium>*/