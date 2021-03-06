using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IOtherTransportService
	{
		Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model);

		Task<UpdateResponse<ApiOtherTransportResponseModel>> Update(int id,
		                                                             ApiOtherTransportRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOtherTransportResponseModel> Get(int id);

		Task<List<ApiOtherTransportResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>807d7641a25f995041d7b24aaf4d3c93</Hash>
</Codenesium>*/