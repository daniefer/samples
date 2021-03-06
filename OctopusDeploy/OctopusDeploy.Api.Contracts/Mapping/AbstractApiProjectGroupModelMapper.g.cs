using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiProjectGroupModelMapper
	{
		public virtual ApiProjectGroupResponseModel MapRequestToResponse(
			string id,
			ApiProjectGroupRequestModel request)
		{
			var response = new ApiProjectGroupResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiProjectGroupRequestModel MapResponseToRequest(
			ApiProjectGroupResponseModel response)
		{
			var request = new ApiProjectGroupRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiProjectGroupRequestModel> CreatePatch(ApiProjectGroupRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProjectGroupRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>12e27903a80e85e248761057aa7f88f4</Hash>
</Codenesium>*/