using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "State")]
        [Trait("Area", "Integration")]
        public class StateIntegrationTests : IClassFixture<WebApplicationTestFixture<TestStartup>>
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
    <Hash>536429f78052758d06947d1c970ee3b1</Hash>
</Codenesium>*/