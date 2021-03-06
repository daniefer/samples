using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IStudentXFamilyService
	{
		Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
			ApiStudentXFamilyRequestModel model);

		Task<UpdateResponse<ApiStudentXFamilyResponseModel>> Update(int id,
		                                                             ApiStudentXFamilyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentXFamilyResponseModel> Get(int id);

		Task<List<ApiStudentXFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a672b6f406a26242f83039455d000b67</Hash>
</Codenesium>*/