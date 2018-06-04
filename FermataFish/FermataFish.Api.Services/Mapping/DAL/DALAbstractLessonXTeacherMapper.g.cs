using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALLessonXTeacherMapper
	{
		public virtual LessonXTeacher MapBOToEF(
			BOLessonXTeacher bo)
		{
			LessonXTeacher efLessonXTeacher = new LessonXTeacher ();

			efLessonXTeacher.SetProperties(
				bo.Id,
				bo.LessonId,
				bo.StudentId);
			return efLessonXTeacher;
		}

		public virtual BOLessonXTeacher MapEFToBO(
			LessonXTeacher ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOLessonXTeacher();

			bo.SetProperties(
				ef.Id,
				ef.LessonId,
				ef.StudentId);
			return bo;
		}

		public virtual List<BOLessonXTeacher> MapEFToBO(
			List<LessonXTeacher> records)
		{
			List<BOLessonXTeacher> response = new List<BOLessonXTeacher>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52c5dc767c656e56c55a66466725b5be</Hash>
</Codenesium>*/