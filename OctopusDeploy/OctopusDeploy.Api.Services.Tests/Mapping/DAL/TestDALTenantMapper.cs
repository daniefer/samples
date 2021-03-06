using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "DALMapper")]
	public class TestDALTenantMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTenantMapper();
			var bo = new BOTenant();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A");

			Tenant response = mapper.MapBOToEF(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTenantMapper();
			Tenant entity = new Tenant();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A");

			BOTenant response = mapper.MapEFToBO(entity);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTenantMapper();
			Tenant entity = new Tenant();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A");

			List<BOTenant> response = mapper.MapEFToBO(new List<Tenant>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5f6b70dffb24075a08a4b43c842b5494</Hash>
</Codenesium>*/