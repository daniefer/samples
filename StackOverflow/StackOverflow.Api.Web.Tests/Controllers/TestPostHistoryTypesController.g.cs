using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "Controllers")]
	public partial class PostHistoryTypesControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var record = new ApiPostHistoryTypesResponseModel();
			var records = new List<ApiPostHistoryTypesResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypesResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPostHistoryTypesResponseModel>>(new List<ApiPostHistoryTypesResponseModel>()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypesResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPostHistoryTypesResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPostHistoryTypesResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPostHistoryTypesResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesResponseModel>>(mockResponse));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypesRequestModel>();
			records.Add(new ApiPostHistoryTypesRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiPostHistoryTypesResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypesResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesResponseModel>>(mockResponse.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypesRequestModel>();
			records.Add(new ApiPostHistoryTypesRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPostHistoryTypesResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPostHistoryTypesResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesResponseModel>>(mockResponse));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypesRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPostHistoryTypesResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypesResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiPostHistoryTypesResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesResponseModel>>(mockResponse.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypesRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>()))
			.Callback<int, ApiPostHistoryTypesRequestModel>(
				(id, model) => model.Type.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesResponseModel>(new ApiPostHistoryTypesResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypesRequestModel>();
			patch.Replace(x => x.Type, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypesRequestModel>();
			patch.Replace(x => x.Type, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PostHistoryTypesControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PostHistoryTypesController>> LoggerMock { get; set; } = new Mock<ILogger<PostHistoryTypesController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPostHistoryTypesService> ServiceMock { get; set; } = new Mock<IPostHistoryTypesService>();

		public Mock<IApiPostHistoryTypesModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPostHistoryTypesModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4096f58d398882e8d8b1aa2d5ea185f9</Hash>
</Codenesium>*/