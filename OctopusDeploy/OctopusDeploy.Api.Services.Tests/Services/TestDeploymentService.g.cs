using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Deployment")]
        [Trait("Area", "Services")]
        public partial class DeploymentServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var records = new List<Deployment>();
                        records.Add(new Deployment());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var record = new Deployment();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        ApiDeploymentResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Deployment>(null));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        ApiDeploymentResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var model = new ApiDeploymentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Deployment>())).Returns(Task.FromResult(new Deployment()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        CreateResponse<ApiDeploymentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Deployment>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var model = new ApiDeploymentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Deployment>())).Returns(Task.FromResult(new Deployment()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Deployment>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var model = new ApiDeploymentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetChannelId_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var records = new List<Deployment>();
                        records.Add(new Deployment());
                        mock.RepositoryMock.Setup(x => x.GetChannelId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetChannelId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetChannelId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetChannelId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetChannelId(It.IsAny<string>())).Returns(Task.FromResult<List<Deployment>>(new List<Deployment>()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetChannelId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetChannelId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var records = new List<Deployment>();
                        records.Add(new Deployment());
                        mock.RepositoryMock.Setup(x => x.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(default(string), default(string), default(string), default(string), default(DateTimeOffset), default(string), default(string), default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<Deployment>>(new List<Deployment>()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(default(string), default(string), default(string), default(string), default(DateTimeOffset), default(string), default(string), default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetTenantId_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var records = new List<Deployment>();
                        records.Add(new Deployment());
                        mock.RepositoryMock.Setup(x => x.GetTenantId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetTenantId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetTenantId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetTenantId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetTenantId(It.IsAny<string>())).Returns(Task.FromResult<List<Deployment>>(new List<Deployment>()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentResponseModel> response = await service.GetTenantId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetTenantId(It.IsAny<string>()));
                }

                [Fact]
                public async void DeploymentRelatedMachines_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        var records = new List<DeploymentRelatedMachine>();
                        records.Add(new DeploymentRelatedMachine());
                        mock.RepositoryMock.Setup(x => x.DeploymentRelatedMachines(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentRelatedMachineResponseModel> response = await service.DeploymentRelatedMachines(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.DeploymentRelatedMachines(default(string), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void DeploymentRelatedMachines_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentRepository>();
                        mock.RepositoryMock.Setup(x => x.DeploymentRelatedMachines(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeploymentRelatedMachine>>(new List<DeploymentRelatedMachine>()));
                        var service = new DeploymentService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.DeploymentModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLDeploymentMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentMapperMock,
                                                            mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
                                                            mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

                        List<ApiDeploymentRelatedMachineResponseModel> response = await service.DeploymentRelatedMachines(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.DeploymentRelatedMachines(default(string), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>5b448e7c1baa0f07925f4566caaf477b</Hash>
</Codenesium>*/