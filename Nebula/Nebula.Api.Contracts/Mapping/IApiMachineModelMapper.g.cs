using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiMachineModelMapper
	{
		ApiMachineResponseModel MapRequestToResponse(
			int id,
			ApiMachineRequestModel request);

		ApiMachineRequestModel MapResponseToRequest(
			ApiMachineResponseModel response);

		JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9c64a55c76477c9e1178e178fa553972</Hash>
</Codenesium>*/