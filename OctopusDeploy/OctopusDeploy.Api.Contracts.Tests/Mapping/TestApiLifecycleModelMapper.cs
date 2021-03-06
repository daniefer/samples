using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Lifecycle")]
	[Trait("Area", "ApiModel")]
	public class TestApiLifecycleModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLifecycleModelMapper();
			var model = new ApiLifecycleRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A");
			ApiLifecycleResponseModel response = mapper.MapRequestToResponse("A", model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLifecycleModelMapper();
			var model = new ApiLifecycleResponseModel();
			model.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
			ApiLifecycleRequestModel response = mapper.MapResponseToRequest(model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLifecycleModelMapper();
			var model = new ApiLifecycleRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A");

			JsonPatchDocument<ApiLifecycleRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLifecycleRequestModel();
			patch.ApplyTo(response);
			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>98733203cfc0524b4d3db1067258786e</Hash>
</Codenesium>*/