using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectGroup")]
        [Trait("Area", "ApiModel")]
        public class TestApiProjectGroupModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProjectGroupModelMapper();
                        var model = new ApiProjectGroupRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A");
                        ApiProjectGroupResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProjectGroupModelMapper();
                        var model = new ApiProjectGroupResponseModel();
                        model.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        ApiProjectGroupRequestModel response = mapper.MapResponseToRequest(model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a2222d8d8749353893983b2896b88f96</Hash>
</Codenesium>*/