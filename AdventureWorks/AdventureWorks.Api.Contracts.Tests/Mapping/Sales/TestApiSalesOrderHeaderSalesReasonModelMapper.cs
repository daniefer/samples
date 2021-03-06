using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderHeaderSalesReason")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesOrderHeaderSalesReasonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSalesOrderHeaderSalesReasonModelMapper();
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSalesOrderHeaderSalesReasonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesOrderID.Should().Be(1);
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSalesOrderHeaderSalesReasonModelMapper();
			var model = new ApiSalesOrderHeaderSalesReasonResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSalesOrderHeaderSalesReasonRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSalesOrderHeaderSalesReasonModelMapper();
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesOrderHeaderSalesReasonRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesReasonID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9e79aa5a574fa0663cb56e44d1a87f2c</Hash>
</Codenesium>*/