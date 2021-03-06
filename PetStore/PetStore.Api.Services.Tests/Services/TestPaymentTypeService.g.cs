using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "Services")]
	public partial class PaymentTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var records = new List<PaymentType>();
			records.Add(new PaymentType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiPaymentTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var record = new PaymentType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPaymentTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PaymentType>(null));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPaymentTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PaymentType>())).Returns(Task.FromResult(new PaymentType()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPaymentTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPaymentTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PaymentType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PaymentType>())).Returns(Task.FromResult(new PaymentType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPaymentTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPaymentTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PaymentType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var model = new ApiPaymentTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Sales_Exists()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.Sales(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Sales_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPaymentTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new PaymentTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PaymentTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPaymentTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALPaymentTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.Sales(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>097425b038318155da6181307c7a773a</Hash>
</Codenesium>*/