using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesOrderDetailMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSalesOrderDetailMapper();
			var bo = new BOSalesOrderDetail();
			bo.SetProperties(1, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);

			SalesOrderDetail response = mapper.MapBOToEF(bo);

			response.CarrierTrackingNumber.Should().Be("A");
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderDetailID.Should().Be(1);
			response.SalesOrderID.Should().Be(1);
			response.SpecialOfferID.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
			response.UnitPriceDiscount.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSalesOrderDetailMapper();
			SalesOrderDetail entity = new SalesOrderDetail();
			entity.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1m, 1m);

			BOSalesOrderDetail response = mapper.MapEFToBO(entity);

			response.CarrierTrackingNumber.Should().Be("A");
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderDetailID.Should().Be(1);
			response.SalesOrderID.Should().Be(1);
			response.SpecialOfferID.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
			response.UnitPriceDiscount.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSalesOrderDetailMapper();
			SalesOrderDetail entity = new SalesOrderDetail();
			entity.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, 1m, 1m);

			List<BOSalesOrderDetail> response = mapper.MapEFToBO(new List<SalesOrderDetail>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>940fbbcd1635df7cddad81259f490912</Hash>
</Codenesium>*/