using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAdminRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminRequestModelValidator>();

		public Mock<IApiCityRequestModelValidator> CityModelValidatorMock { get; set; } = new Mock<IApiCityRequestModelValidator>();

		public Mock<IApiCountryRequestModelValidator> CountryModelValidatorMock { get; set; } = new Mock<IApiCountryRequestModelValidator>();

		public Mock<IApiCustomerRequestModelValidator> CustomerModelValidatorMock { get; set; } = new Mock<IApiCustomerRequestModelValidator>();

		public Mock<IApiEventRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventRequestModelValidator>();

		public Mock<IApiProvinceRequestModelValidator> ProvinceModelValidatorMock { get; set; } = new Mock<IApiProvinceRequestModelValidator>();

		public Mock<IApiSaleRequestModelValidator> SaleModelValidatorMock { get; set; } = new Mock<IApiSaleRequestModelValidator>();

		public Mock<IApiSaleTicketsRequestModelValidator> SaleTicketsModelValidatorMock { get; set; } = new Mock<IApiSaleTicketsRequestModelValidator>();

		public Mock<IApiTicketRequestModelValidator> TicketModelValidatorMock { get; set; } = new Mock<IApiTicketRequestModelValidator>();

		public Mock<IApiTicketStatusRequestModelValidator> TicketStatusModelValidatorMock { get; set; } = new Mock<IApiTicketStatusRequestModelValidator>();

		public Mock<IApiTransactionRequestModelValidator> TransactionModelValidatorMock { get; set; } = new Mock<IApiTransactionRequestModelValidator>();

		public Mock<IApiTransactionStatusRequestModelValidator> TransactionStatusModelValidatorMock { get; set; } = new Mock<IApiTransactionStatusRequestModelValidator>();

		public Mock<IApiVenueRequestModelValidator> VenueModelValidatorMock { get; set; } = new Mock<IApiVenueRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CityModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CityModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CountryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CountryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CustomerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CustomerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProvinceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProvinceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SaleTicketsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleTicketsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SaleTicketsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TicketStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TicketStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TransactionStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TransactionStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VenueModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVenueRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VenueModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>e9fd3ea1cde1abd05f441538435dbb88</Hash>
</Codenesium>*/