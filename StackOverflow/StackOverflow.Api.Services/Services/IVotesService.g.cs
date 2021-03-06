using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IVotesService
	{
		Task<CreateResponse<ApiVotesResponseModel>> Create(
			ApiVotesRequestModel model);

		Task<UpdateResponse<ApiVotesResponseModel>> Update(int id,
		                                                    ApiVotesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVotesResponseModel> Get(int id);

		Task<List<ApiVotesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>91d4cbfd46c3bd196d9142a3fbe1e7ff</Hash>
</Codenesium>*/