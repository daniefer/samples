using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentProcess")]
        [Trait("Area", "ApiModel")]
        public class TestApiDeploymentProcessModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDeploymentProcessModelMapper();
                        var model = new ApiDeploymentProcessRequestModel();
                        model.SetProperties(true, "A", "A", "A", 1);
                        ApiDeploymentProcessResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDeploymentProcessModelMapper();
                        var model = new ApiDeploymentProcessResponseModel();
                        model.SetProperties("A", true, "A", "A", "A", 1);
                        ApiDeploymentProcessRequestModel response = mapper.MapResponseToRequest(model);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>30965872e3b592c6bf9b02b7904de682</Hash>
</Codenesium>*/