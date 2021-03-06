using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Integration")]
	public class MachineIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MachineIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestCreate()
		{
			var response = await this.CreateRecord();

			response.Should().NotBeNull();

			await this.Cleanup();
		}

		[Fact]
		public async void TestUpdate()
		{
			var model = await this.CreateRecord();

			ApiMachineModelMapper mapper = new ApiMachineModelMapper();

			UpdateResponse<ApiMachineResponseModel> updateResponse = await this.Client.MachineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MachineDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMachineResponseModel response = await this.Client.MachineGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMachineResponseModel> response = await this.Client.MachineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMachineResponseModel> CreateRecord()
		{
			var model = new ApiMachineRequestModel();
			model.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiMachineResponseModel> result = await this.Client.MachineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MachineDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>ff088169db18bf06f30d3228d962658f</Hash>
</Codenesium>*/