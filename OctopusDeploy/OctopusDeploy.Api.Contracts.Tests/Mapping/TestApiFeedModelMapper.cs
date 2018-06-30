using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Feed")]
        [Trait("Area", "ApiModel")]
        public class TestApiFeedModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiFeedModelMapper();
                        var model = new ApiFeedRequestModel();
                        model.SetProperties("A", "A", "A", "A");
                        ApiFeedResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiFeedModelMapper();
                        var model = new ApiFeedResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A");
                        ApiFeedRequestModel response = mapper.MapResponseToRequest(model);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>dca1c384d855f4000d559f46beb9099c</Hash>
</Codenesium>*/