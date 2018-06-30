using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Invitation")]
        [Trait("Area", "ApiModel")]
        public class TestApiInvitationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiInvitationModelMapper();
                        var model = new ApiInvitationRequestModel();
                        model.SetProperties("A", "A");
                        ApiInvitationResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiInvitationModelMapper();
                        var model = new ApiInvitationResponseModel();
                        model.SetProperties("A", "A", "A");
                        ApiInvitationRequestModel response = mapper.MapResponseToRequest(model);

                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>62779b3bb2eb255f898c0d138659cb04</Hash>
</Codenesium>*/