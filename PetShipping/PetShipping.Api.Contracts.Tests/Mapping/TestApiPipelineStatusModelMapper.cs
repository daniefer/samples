using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatusModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPipelineStatusModelMapper();
			var model = new ApiPipelineStatusRequestModel();
			model.SetProperties("A");
			ApiPipelineStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPipelineStatusModelMapper();
			var model = new ApiPipelineStatusResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStatusModelMapper();
			var model = new ApiPipelineStatusRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0b90a1bf1d6b1e9242e7addef6d16cfe</Hash>
</Codenesium>*/