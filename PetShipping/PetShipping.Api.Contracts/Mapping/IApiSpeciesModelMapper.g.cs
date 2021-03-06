using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiSpeciesModelMapper
	{
		ApiSpeciesResponseModel MapRequestToResponse(
			int id,
			ApiSpeciesRequestModel request);

		ApiSpeciesRequestModel MapResponseToRequest(
			ApiSpeciesResponseModel response);

		JsonPatchDocument<ApiSpeciesRequestModel> CreatePatch(ApiSpeciesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>aee6b088902a595b6e772d715275c9c4</Hash>
</Codenesium>*/