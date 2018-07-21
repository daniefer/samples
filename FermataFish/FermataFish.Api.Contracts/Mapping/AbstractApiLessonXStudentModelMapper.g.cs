using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonXStudentModelMapper
        {
                public virtual ApiLessonXStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXStudentRequestModel request)
                {
                        var response = new ApiLessonXStudentResponseModel();
                        response.SetProperties(id,
                                               request.LessonId,
                                               request.StudentId);
                        return response;
                }

                public virtual ApiLessonXStudentRequestModel MapResponseToRequest(
                        ApiLessonXStudentResponseModel response)
                {
                        var request = new ApiLessonXStudentRequestModel();
                        request.SetProperties(
                                response.LessonId,
                                response.StudentId);
                        return request;
                }

                public JsonPatchDocument<ApiLessonXStudentRequestModel> CreatePatch(ApiLessonXStudentRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLessonXStudentRequestModel>();
                        patch.Replace(x => x.LessonId, model.LessonId);
                        patch.Replace(x => x.StudentId, model.StudentId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>fc753a5ca308ebfa1d7b8e74ebd82bf2</Hash>
</Codenesium>*/