using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiSaleModelMapper
	{
		ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request);

		ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response);

		JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3e31bf55daee23e997382c3fff01a8b9</Hash>
</Codenesium>*/