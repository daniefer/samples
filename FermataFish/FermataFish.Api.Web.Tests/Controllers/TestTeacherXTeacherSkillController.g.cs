using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
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
using Xunit;

namespace FermataFishNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherXTeacherSkill")]
	[Trait("Area", "Controllers")]
	public partial class TeacherXTeacherSkillControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var record = new ApiTeacherXTeacherSkillResponseModel();
			var records = new List<ApiTeacherXTeacherSkillResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherXTeacherSkillResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTeacherXTeacherSkillResponseModel>>(new List<ApiTeacherXTeacherSkillResponseModel>()));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherXTeacherSkillResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherXTeacherSkillResponseModel()));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTeacherXTeacherSkillResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherXTeacherSkillResponseModel>(null));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTeacherXTeacherSkillResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResponse));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherXTeacherSkillRequestModel>();
			records.Add(new ApiTeacherXTeacherSkillRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTeacherXTeacherSkillResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResponse.Object));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherXTeacherSkillRequestModel>();
			records.Add(new ApiTeacherXTeacherSkillRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTeacherXTeacherSkillResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResponse));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherXTeacherSkillRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTeacherXTeacherSkillResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTeacherXTeacherSkillResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResponse.Object));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherXTeacherSkillRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>()))
			.Callback<int, ApiTeacherXTeacherSkillRequestModel>(
				(id, model) => model.TeacherId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherXTeacherSkillResponseModel>(new ApiTeacherXTeacherSkillResponseModel()));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherXTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherXTeacherSkillResponseModel>(null));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherXTeacherSkillResponseModel()));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherXTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherXTeacherSkillRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherXTeacherSkillResponseModel()));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherXTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherXTeacherSkillRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherXTeacherSkillResponseModel>(null));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherXTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherXTeacherSkillRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TeacherXTeacherSkillControllerMockFacade mock = new TeacherXTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TeacherXTeacherSkillController controller = new TeacherXTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TeacherXTeacherSkillControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TeacherXTeacherSkillController>> LoggerMock { get; set; } = new Mock<ILogger<TeacherXTeacherSkillController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITeacherXTeacherSkillService> ServiceMock { get; set; } = new Mock<ITeacherXTeacherSkillService>();

		public Mock<IApiTeacherXTeacherSkillModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTeacherXTeacherSkillModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4c7701f72f1f856dd60039a7e803a14a</Hash>
</Codenesium>*/