using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "Integration")]
        public class DeploymentEnvironmentIntegrationTests : IClassFixture<WebApplicationTestFixture<TestStartup>>
        {
                public MyApplicationFunctionalTests(WebApplicationTestFixture<TestStartup> fixture)
                {
                        this.Client = new ApiClient(fixture.Client);
                }

                public ApiClient Client { get; }

                [Fact]
                public async void TestCreate()
                {
                }

                [Fact]
                public async void TestUpdate()
                {
                }

                [Fact]
                public async void TestDelete()
                {
                }

                [Fact]
                public async void TestGet()
                {
                }

                [Fact]
                public async void TestAll()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e882acaafec80d034e9536a89143ca7e</Hash>
</Codenesium>*/