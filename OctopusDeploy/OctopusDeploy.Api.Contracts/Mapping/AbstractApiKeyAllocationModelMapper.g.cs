using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiKeyAllocationModelMapper
        {
                public virtual ApiKeyAllocationResponseModel MapRequestToResponse(
                        string collectionName,
                        ApiKeyAllocationRequestModel request)
                {
                        var response = new ApiKeyAllocationResponseModel();
                        response.SetProperties(collectionName,
                                               request.Allocated);
                        return response;
                }

                public virtual ApiKeyAllocationRequestModel MapResponseToRequest(
                        ApiKeyAllocationResponseModel response)
                {
                        var request = new ApiKeyAllocationRequestModel();
                        request.SetProperties(
                                response.Allocated);
                        return request;
                }

                public JsonPatchDocument<ApiKeyAllocationRequestModel> CreatePatch(ApiKeyAllocationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiKeyAllocationRequestModel>();
                        patch.Replace(x => x.Allocated, model.Allocated);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>0d6da2d9f013dd9391c90c7d5b0409fa</Hash>
</Codenesium>*/