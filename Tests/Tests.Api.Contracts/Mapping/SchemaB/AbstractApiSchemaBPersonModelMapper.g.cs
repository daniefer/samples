using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiSchemaBPersonModelMapper
	{
		public virtual ApiSchemaBPersonResponseModel MapRequestToResponse(
			int id,
			ApiSchemaBPersonRequestModel request)
		{
			var response = new ApiSchemaBPersonResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaBPersonRequestModel MapResponseToRequest(
			ApiSchemaBPersonResponseModel response)
		{
			var request = new ApiSchemaBPersonRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSchemaBPersonRequestModel> CreatePatch(ApiSchemaBPersonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSchemaBPersonRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cbc5ffc29d781221e87557c01c5de725</Hash>
</Codenesium>*/