using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		Task<Rate> Create(Rate item);

		Task Update(Rate item);

		Task Delete(int id);

		Task<Rate> Get(int id);

		Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0);

		Task<Teacher> GetTeacher(int teacherId);

		Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>b29268b6717d79eef9c62bae885b80b7</Hash>
</Codenesium>*/