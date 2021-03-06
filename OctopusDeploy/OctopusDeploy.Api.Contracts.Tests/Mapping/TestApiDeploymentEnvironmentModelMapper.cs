using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeploymentEnvironment")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeploymentEnvironmentModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDeploymentEnvironmentModelMapper();
			var model = new ApiDeploymentEnvironmentRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A", 1);
			ApiDeploymentEnvironmentResponseModel response = mapper.MapRequestToResponse("A", model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDeploymentEnvironmentModelMapper();
			var model = new ApiDeploymentEnvironmentResponseModel();
			model.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
			ApiDeploymentEnvironmentRequestModel response = mapper.MapResponseToRequest(model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeploymentEnvironmentModelMapper();
			var model = new ApiDeploymentEnvironmentRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A", 1);

			JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeploymentEnvironmentRequestModel();
			patch.ApplyTo(response);
			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3b17ee167bebc5f2ac01c9490c47417f</Hash>
</Codenesium>*/