using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALAdminMapper DALAdminMapperMock { get; set; } = new DALAdminMapper();

		public IDALFamilyMapper DALFamilyMapperMock { get; set; } = new DALFamilyMapper();

		public IDALLessonMapper DALLessonMapperMock { get; set; } = new DALLessonMapper();

		public IDALLessonStatusMapper DALLessonStatusMapperMock { get; set; } = new DALLessonStatusMapper();

		public IDALLessonXStudentMapper DALLessonXStudentMapperMock { get; set; } = new DALLessonXStudentMapper();

		public IDALLessonXTeacherMapper DALLessonXTeacherMapperMock { get; set; } = new DALLessonXTeacherMapper();

		public IDALRateMapper DALRateMapperMock { get; set; } = new DALRateMapper();

		public IDALSpaceMapper DALSpaceMapperMock { get; set; } = new DALSpaceMapper();

		public IDALSpaceFeatureMapper DALSpaceFeatureMapperMock { get; set; } = new DALSpaceFeatureMapper();

		public IDALSpaceXSpaceFeatureMapper DALSpaceXSpaceFeatureMapperMock { get; set; } = new DALSpaceXSpaceFeatureMapper();

		public IDALStateMapper DALStateMapperMock { get; set; } = new DALStateMapper();

		public IDALStudentMapper DALStudentMapperMock { get; set; } = new DALStudentMapper();

		public IDALStudentXFamilyMapper DALStudentXFamilyMapperMock { get; set; } = new DALStudentXFamilyMapper();

		public IDALStudioMapper DALStudioMapperMock { get; set; } = new DALStudioMapper();

		public IDALTeacherMapper DALTeacherMapperMock { get; set; } = new DALTeacherMapper();

		public IDALTeacherSkillMapper DALTeacherSkillMapperMock { get; set; } = new DALTeacherSkillMapper();

		public IDALTeacherXTeacherSkillMapper DALTeacherXTeacherSkillMapperMock { get; set; } = new DALTeacherXTeacherSkillMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>342ed43e8d2f7dc0edb96195272f97aa</Hash>
</Codenesium>*/