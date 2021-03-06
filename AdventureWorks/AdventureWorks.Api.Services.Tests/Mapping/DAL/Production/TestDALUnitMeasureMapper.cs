using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "DALMapper")]
	public class TestDALUnitMeasureMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALUnitMeasureMapper();
			var bo = new BOUnitMeasure();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			UnitMeasure response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			BOUnitMeasure response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			List<BOUnitMeasure> response = mapper.MapEFToBO(new List<UnitMeasure>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8a412525c8092afa5b21af88787bdf62</Hash>
</Codenesium>*/