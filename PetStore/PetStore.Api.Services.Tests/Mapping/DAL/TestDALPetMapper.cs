using FluentAssertions;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "DALMapper")]
	public class TestDALPetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPetMapper();
			var bo = new BOPet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);

			Pet response = mapper.MapBOToEF(bo);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPetMapper();
			Pet entity = new Pet();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1m, 1);

			BOPet response = mapper.MapEFToBO(entity);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPetMapper();
			Pet entity = new Pet();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1, 1m, 1);

			List<BOPet> response = mapper.MapEFToBO(new List<Pet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>275c2e078ee9c0cf8a3f7f357a10537a</Hash>
</Codenesium>*/