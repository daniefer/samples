using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTransactionHistoryArchiveMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTransactionHistoryArchiveMapper();
			ApiTransactionHistoryArchiveRequestModel model = new ApiTransactionHistoryArchiveRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOTransactionHistoryArchive response = mapper.MapModelToBO(1, model);

			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTransactionHistoryArchiveMapper();
			BOTransactionHistoryArchive bo = new BOTransactionHistoryArchive();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryArchiveResponseModel response = mapper.MapBOToModel(bo);

			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionID.Should().Be(1);
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTransactionHistoryArchiveMapper();
			BOTransactionHistoryArchive bo = new BOTransactionHistoryArchive();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiTransactionHistoryArchiveResponseModel> response = mapper.MapBOToModel(new List<BOTransactionHistoryArchive>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9232849c9fb0b9b12eb6585697c9abf0</Hash>
</Codenesium>*/