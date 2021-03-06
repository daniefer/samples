using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLFamilyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLFamilyMapper();
			ApiFamilyRequestModel model = new ApiFamilyRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", 1);
			BOFamily response = mapper.MapModelToBO(1, model);

			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A", 1);
			ApiFamilyResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A", 1);
			List<ApiFamilyResponseModel> response = mapper.MapBOToModel(new List<BOFamily>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>989b4cc677fcaffbe3a55c22b563ad66</Hash>
</Codenesium>*/