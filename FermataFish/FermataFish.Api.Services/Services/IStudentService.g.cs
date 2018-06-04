using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface IStudentService
	{
		Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentResponseModel> Get(int id);

		Task<List<ApiStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c868c314c5ea9e6a592b406c91777241</Hash>
</Codenesium>*/