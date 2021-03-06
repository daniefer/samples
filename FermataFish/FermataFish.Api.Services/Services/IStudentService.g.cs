using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IStudentService
	{
		Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model);

		Task<UpdateResponse<ApiStudentResponseModel>> Update(int id,
		                                                      ApiStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentResponseModel> Get(int id);

		Task<List<ApiStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c706ec2168b0956feaa3c18d96f72b06</Hash>
</Codenesium>*/