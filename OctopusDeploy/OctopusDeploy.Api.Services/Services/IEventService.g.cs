using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IEventService
        {
                Task<CreateResponse<ApiEventResponseModel>> Create(
                        ApiEventRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiEventRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiEventResponseModel> Get(string id);

                Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventResponseModel>> GetAutoId(long autoId);

                Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId);

                Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId);

                Task<List<ApiEventResponseModel>> GetIdOccurred(string id, DateTimeOffset occurred);

                Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ef870a484c014bab36fb3c10653a4bb2</Hash>
</Codenesium>*/