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
	[Trait("Table", "Proxy")]
	[Trait("Area", "Services")]
	public partial class ProxyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var records = new List<Proxy>();
			records.Add(new Proxy());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			List<ApiProxyResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var record = new Proxy();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			ApiProxyResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			ApiProxyResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var model = new ApiProxyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Proxy>())).Returns(Task.FromResult(new Proxy()));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			CreateResponse<ApiProxyResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProxyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Proxy>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var model = new ApiProxyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Proxy>())).Returns(Task.FromResult(new Proxy()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			UpdateResponse<ApiProxyResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProxyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Proxy>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var model = new ApiProxyRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			var record = new Proxy();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			ApiProxyResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProxyRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
			var service = new ProxyService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ProxyModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLProxyMapperMock,
			                               mock.DALMapperMockFactory.DALProxyMapperMock);

			ApiProxyResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>97e983411364343a539a1f08b15fdbd1</Hash>
</Codenesium>*/