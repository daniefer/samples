using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrderRouting")]
	[Trait("Area", "Services")]
	public partial class WorkOrderRoutingServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var records = new List<WorkOrderRouting>();
			records.Add(new WorkOrderRouting());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			List<ApiWorkOrderRoutingResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var record = new WorkOrderRouting();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			ApiWorkOrderRoutingResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<WorkOrderRouting>(null));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			ApiWorkOrderRoutingResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var model = new ApiWorkOrderRoutingRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrderRouting>())).Returns(Task.FromResult(new WorkOrderRouting()));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			CreateResponse<ApiWorkOrderRoutingResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderRoutingRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<WorkOrderRouting>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var model = new ApiWorkOrderRoutingRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrderRouting>())).Returns(Task.FromResult(new WorkOrderRouting()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new WorkOrderRouting()));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			UpdateResponse<ApiWorkOrderRoutingResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<WorkOrderRouting>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var model = new ApiWorkOrderRoutingRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			var records = new List<WorkOrderRouting>();
			records.Add(new WorkOrderRouting());
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			List<ApiWorkOrderRoutingResponseModel> response = await service.ByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRoutingRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrderRouting>>(new List<WorkOrderRouting>()));
			var service = new WorkOrderRoutingService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.WorkOrderRoutingModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
			                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

			List<ApiWorkOrderRoutingResponseModel> response = await service.ByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>44127cd9135d05147e60904ac8cc3c9c</Hash>
</Codenesium>*/