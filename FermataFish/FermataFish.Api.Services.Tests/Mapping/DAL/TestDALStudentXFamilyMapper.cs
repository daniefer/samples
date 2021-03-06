using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "DALMapper")]
	public class TestDALStudentXFamilyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALStudentXFamilyMapper();
			var bo = new BOStudentXFamily();
			bo.SetProperties(1, 1, 1);

			StudentXFamily response = mapper.MapBOToEF(bo);

			response.FamilyId.Should().Be(1);
			response.Id.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALStudentXFamilyMapper();
			StudentXFamily entity = new StudentXFamily();
			entity.SetProperties(1, 1, 1);

			BOStudentXFamily response = mapper.MapEFToBO(entity);

			response.FamilyId.Should().Be(1);
			response.Id.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALStudentXFamilyMapper();
			StudentXFamily entity = new StudentXFamily();
			entity.SetProperties(1, 1, 1);

			List<BOStudentXFamily> response = mapper.MapEFToBO(new List<StudentXFamily>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8cc2009420f72952440d07c20de9d17d</Hash>
</Codenesium>*/