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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductPhotoMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductPhotoMapper();
			ApiProductPhotoRequestModel model = new ApiProductPhotoRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			BOProductPhoto response = mapper.MapModelToBO(1, model);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductPhotoMapper();
			BOProductPhoto bo = new BOProductPhoto();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoResponseModel response = mapper.MapBOToModel(bo);

			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductPhotoID.Should().Be(1);
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductPhotoMapper();
			BOProductPhoto bo = new BOProductPhoto();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			List<ApiProductPhotoResponseModel> response = mapper.MapBOToModel(new List<BOProductPhoto>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>36a54c718a04b7a66b9c87cdb210d213</Hash>
</Codenesium>*/