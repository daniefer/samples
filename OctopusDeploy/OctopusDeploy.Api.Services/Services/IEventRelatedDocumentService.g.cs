using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IEventRelatedDocumentService
        {
                Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> Create(
                        ApiEventRelatedDocumentRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiEventRelatedDocumentRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiEventRelatedDocumentResponseModel> Get(int id);

                Task<List<ApiEventRelatedDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventRelatedDocumentResponseModel>> GetEventId(string eventId);

                Task<List<ApiEventRelatedDocumentResponseModel>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId);
        }
}

/*<Codenesium>
    <Hash>7fde54af0cdacc7a6d04999606cc7357</Hash>
</Codenesium>*/