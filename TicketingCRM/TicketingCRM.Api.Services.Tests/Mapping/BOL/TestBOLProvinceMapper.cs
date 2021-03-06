using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProvinceMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProvinceMapper();
			ApiProvinceRequestModel model = new ApiProvinceRequestModel();
			model.SetProperties(1, "A");
			BOProvince response = mapper.MapModelToBO(1, model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProvinceMapper();
			BOProvince bo = new BOProvince();
			bo.SetProperties(1, 1, "A");
			ApiProvinceResponseModel response = mapper.MapBOToModel(bo);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProvinceMapper();
			BOProvince bo = new BOProvince();
			bo.SetProperties(1, 1, "A");
			List<ApiProvinceResponseModel> response = mapper.MapBOToModel(new List<BOProvince>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ac96a32f5308a9234c897a3c1ee7d27a</Hash>
</Codenesium>*/