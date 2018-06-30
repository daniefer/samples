using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VariableSet")]
        [Trait("Area", "ApiModel")]
        public class TestApiVariableSetModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVariableSetModelMapper();
                        var model = new ApiVariableSetRequestModel();
                        model.SetProperties(true, "A", "A", "A", 1);
                        ApiVariableSetResponseModel response = mapper.MapRequestToResponse("A", model);

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
                        var mapper = new ApiVariableSetModelMapper();
                        var model = new ApiVariableSetResponseModel();
                        model.SetProperties("A", true, "A", "A", "A", 1);
                        ApiVariableSetRequestModel response = mapper.MapResponseToRequest(model);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3e3a19b3ee1ceefbcb89f0552d782ef9</Hash>
</Codenesium>*/