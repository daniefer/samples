using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiSubscriptionModelMapper
	{
		public virtual ApiSubscriptionResponseModel MapRequestToResponse(
			string id,
			ApiSubscriptionRequestModel request)
		{
			var response = new ApiSubscriptionResponseModel();
			response.SetProperties(id,
			                       request.IsDisabled,
			                       request.JSON,
			                       request.Name,
			                       request.Type);
			return response;
		}

		public virtual ApiSubscriptionRequestModel MapResponseToRequest(
			ApiSubscriptionResponseModel response)
		{
			var request = new ApiSubscriptionRequestModel();
			request.SetProperties(
				response.IsDisabled,
				response.JSON,
				response.Name,
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiSubscriptionRequestModel> CreatePatch(ApiSubscriptionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSubscriptionRequestModel>();
			patch.Replace(x => x.IsDisabled, model.IsDisabled);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>bd5ebb1606b9524c112b804aaf6f6365</Hash>
</Codenesium>*/