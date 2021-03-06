using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiLessonXTeacherModelMapper
	{
		public virtual ApiLessonXTeacherResponseModel MapRequestToResponse(
			int id,
			ApiLessonXTeacherRequestModel request)
		{
			var response = new ApiLessonXTeacherResponseModel();
			response.SetProperties(id,
			                       request.LessonId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiLessonXTeacherRequestModel MapResponseToRequest(
			ApiLessonXTeacherResponseModel response)
		{
			var request = new ApiLessonXTeacherRequestModel();
			request.SetProperties(
				response.LessonId,
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiLessonXTeacherRequestModel> CreatePatch(ApiLessonXTeacherRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLessonXTeacherRequestModel>();
			patch.Replace(x => x.LessonId, model.LessonId);
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7a0afe1d115cd120d3328eb8a16c0c5e</Hash>
</Codenesium>*/