using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Proxy")]
	[Trait("Area", "DALMapper")]
	public class TestDALProxyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProxyMapper();
			var bo = new BOProxy();
			bo.SetProperties("A", "A", "A");

			Proxy response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProxyMapper();
			Proxy entity = new Proxy();
			entity.SetProperties("A", "A", "A");

			BOProxy response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProxyMapper();
			Proxy entity = new Proxy();
			entity.SetProperties("A", "A", "A");

			List<BOProxy> response = mapper.MapEFToBO(new List<Proxy>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>42bc9f9b32cc0026e860b83545849ce8</Hash>
</Codenesium>*/