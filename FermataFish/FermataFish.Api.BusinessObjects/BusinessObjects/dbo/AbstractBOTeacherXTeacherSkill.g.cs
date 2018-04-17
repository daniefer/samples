using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOTeacherXTeacherSkill
	{
		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;
		private ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator;
		private ILogger logger;

		public AbstractBOTeacherXTeacherSkill(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator)

		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TeacherXTeacherSkillModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.teacherXTeacherSkillRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			TeacherXTeacherSkillModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.teacherXTeacherSkillRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teacherXTeacherSkillRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.teacherXTeacherSkillRepository.GetById(id);
		}

		public virtual POCOTeacherXTeacherSkill GetByIdDirect(int id)
		{
			return this.teacherXTeacherSkillRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherXTeacherSkillRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherXTeacherSkillRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherXTeacherSkillRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>327f88a0bed23bde245acfef40253d3b</Hash>
</Codenesium>*/