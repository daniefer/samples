using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;

using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FermataFishNS.Api.Client;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Integration", " Space")]
	public class SpaceTests
	{
		private TestServer server;
		private ApiClient client;

		public SpaceTests()
		{}

		[Fact]
		public async void TestCreate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestUpdate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestDelete()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestGetById()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestSearch()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestBulkInsert()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}
	}
}

/*<Codenesium>
    <Hash>409a2ba5760799322bc75fbbb42cd1c2</Hash>
</Codenesium>*/