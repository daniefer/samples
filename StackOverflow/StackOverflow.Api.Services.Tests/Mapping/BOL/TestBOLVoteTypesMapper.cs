using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVoteTypesMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVoteTypesMapper();
			ApiVoteTypesRequestModel model = new ApiVoteTypesRequestModel();
			model.SetProperties("A");
			BOVoteTypes response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVoteTypesMapper();
			BOVoteTypes bo = new BOVoteTypes();
			bo.SetProperties(1, "A");
			ApiVoteTypesResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVoteTypesMapper();
			BOVoteTypes bo = new BOVoteTypes();
			bo.SetProperties(1, "A");
			List<ApiVoteTypesResponseModel> response = mapper.MapBOToModel(new List<BOVoteTypes>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>445554fc27c1b392114285690e0071a0</Hash>
</Codenesium>*/