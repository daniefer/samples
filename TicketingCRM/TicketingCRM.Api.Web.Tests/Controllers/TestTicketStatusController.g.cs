using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "Controllers")]
	public partial class TicketStatusControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var record = new ApiTicketStatusResponseModel();
			var records = new List<ApiTicketStatusResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTicketStatusResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTicketStatusResponseModel>>(new List<ApiTicketStatusResponseModel>()));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTicketStatusResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTicketStatusResponseModel()));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTicketStatusResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTicketStatusResponseModel>(null));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTicketStatusResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTicketStatusResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTicketStatusResponseModel>>(mockResponse));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTicketStatusRequestModel>();
			records.Add(new ApiTicketStatusRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTicketStatusResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTicketStatusResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTicketStatusResponseModel>>(mockResponse.Object));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTicketStatusRequestModel>();
			records.Add(new ApiTicketStatusRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTicketStatusResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTicketStatusResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTicketStatusResponseModel>>(mockResponse));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTicketStatusRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTicketStatusResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTicketStatusResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTicketStatusResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTicketStatusResponseModel>>(mockResponse.Object));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTicketStatusRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTicketStatusResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>()))
			.Callback<int, ApiTicketStatusRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTicketStatusResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTicketStatusResponseModel>(new ApiTicketStatusResponseModel()));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTicketStatusModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTicketStatusRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTicketStatusResponseModel>(null));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTicketStatusRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTicketStatusResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTicketStatusResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTicketStatusResponseModel()));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTicketStatusModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTicketStatusRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTicketStatusResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTicketStatusResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTicketStatusResponseModel()));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTicketStatusModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTicketStatusRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTicketStatusResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTicketStatusResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTicketStatusResponseModel>(null));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTicketStatusModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTicketStatusRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TicketStatusControllerMockFacade mock = new TicketStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TicketStatusController controller = new TicketStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TicketStatusControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TicketStatusController>> LoggerMock { get; set; } = new Mock<ILogger<TicketStatusController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITicketStatusService> ServiceMock { get; set; } = new Mock<ITicketStatusService>();

		public Mock<IApiTicketStatusModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTicketStatusModelMapper>();
	}
}

/*<Codenesium>
    <Hash>0991268c2b5d6f2ea32fe3add1958968</Hash>
</Codenesium>*/