using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DashboardConfiguration")]
	[Trait("Area", "Controllers")]
	public partial class DashboardConfigurationControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var record = new ApiDashboardConfigurationResponseModel();
			var records = new List<ApiDashboardConfigurationResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDashboardConfigurationResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDashboardConfigurationResponseModel>>(new List<ApiDashboardConfigurationResponseModel>()));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDashboardConfigurationResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDashboardConfigurationResponseModel()));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDashboardConfigurationResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDashboardConfigurationResponseModel>(null));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();

			var mockResponse = new CreateResponse<ApiDashboardConfigurationResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiDashboardConfigurationResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDashboardConfigurationResponseModel>>(mockResponse));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDashboardConfigurationRequestModel>();
			records.Add(new ApiDashboardConfigurationRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiDashboardConfigurationResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDashboardConfigurationResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDashboardConfigurationResponseModel>>(mockResponse.Object));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDashboardConfigurationRequestModel>();
			records.Add(new ApiDashboardConfigurationRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();

			var mockResponse = new CreateResponse<ApiDashboardConfigurationResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiDashboardConfigurationResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDashboardConfigurationResponseModel>>(mockResponse));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDashboardConfigurationRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDashboardConfigurationResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDashboardConfigurationResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiDashboardConfigurationResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDashboardConfigurationResponseModel>>(mockResponse.Object));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDashboardConfigurationRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDashboardConfigurationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>()))
			.Callback<string, ApiDashboardConfigurationRequestModel>(
				(id, model) => model.IncludedEnvironmentIds.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDashboardConfigurationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDashboardConfigurationResponseModel>(new ApiDashboardConfigurationResponseModel()));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDashboardConfigurationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDashboardConfigurationRequestModel>();
			patch.Replace(x => x.IncludedEnvironmentIds, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDashboardConfigurationResponseModel>(null));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDashboardConfigurationRequestModel>();
			patch.Replace(x => x.IncludedEnvironmentIds, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDashboardConfigurationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDashboardConfigurationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDashboardConfigurationResponseModel()));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDashboardConfigurationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiDashboardConfigurationRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDashboardConfigurationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDashboardConfigurationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDashboardConfigurationResponseModel()));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDashboardConfigurationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiDashboardConfigurationRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDashboardConfigurationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDashboardConfigurationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDashboardConfigurationResponseModel>(null));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDashboardConfigurationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiDashboardConfigurationRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			DashboardConfigurationControllerMockFacade mock = new DashboardConfigurationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DashboardConfigurationController controller = new DashboardConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class DashboardConfigurationControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<DashboardConfigurationController>> LoggerMock { get; set; } = new Mock<ILogger<DashboardConfigurationController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IDashboardConfigurationService> ServiceMock { get; set; } = new Mock<IDashboardConfigurationService>();

		public Mock<IApiDashboardConfigurationModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDashboardConfigurationModelMapper>();
	}
}

/*<Codenesium>
    <Hash>ec735afddbe5d09cf086f97922f256df</Hash>
</Codenesium>*/