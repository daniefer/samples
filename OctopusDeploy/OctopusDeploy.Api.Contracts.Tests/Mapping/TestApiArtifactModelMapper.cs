using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Artifact")]
        [Trait("Area", "ApiModel")]
        public class TestApiArtifactModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiArtifactModelMapper();
                        var model = new ApiArtifactRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        ApiArtifactResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.Filename.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiArtifactModelMapper();
                        var model = new ApiArtifactResponseModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
                        ApiArtifactRequestModel response = mapper.MapResponseToRequest(model);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.Filename.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>f40b85c6941330ded8b844265817c8df</Hash>
</Codenesium>*/