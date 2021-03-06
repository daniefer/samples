using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractTeacherXTeacherSkillMapper
	{
		public virtual TeacherXTeacherSkill MapBOToEF(
			BOTeacherXTeacherSkill bo)
		{
			TeacherXTeacherSkill efTeacherXTeacherSkill = new TeacherXTeacherSkill();
			efTeacherXTeacherSkill.SetProperties(
				bo.Id,
				bo.TeacherId,
				bo.TeacherSkillId);
			return efTeacherXTeacherSkill;
		}

		public virtual BOTeacherXTeacherSkill MapEFToBO(
			TeacherXTeacherSkill ef)
		{
			var bo = new BOTeacherXTeacherSkill();

			bo.SetProperties(
				ef.Id,
				ef.TeacherId,
				ef.TeacherSkillId);
			return bo;
		}

		public virtual List<BOTeacherXTeacherSkill> MapEFToBO(
			List<TeacherXTeacherSkill> records)
		{
			List<BOTeacherXTeacherSkill> response = new List<BOTeacherXTeacherSkill>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc15bf0ca614a9f0eb0273d5c29c4899</Hash>
</Codenesium>*/