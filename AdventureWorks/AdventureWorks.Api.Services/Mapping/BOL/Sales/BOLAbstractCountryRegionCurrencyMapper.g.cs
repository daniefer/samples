using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCountryRegionCurrencyMapper
	{
		public virtual BOCountryRegionCurrency MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model
			)
		{
			BOCountryRegionCurrency boCountryRegionCurrency = new BOCountryRegionCurrency();
			boCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
			return boCountryRegionCurrency;
		}

		public virtual ApiCountryRegionCurrencyResponseModel MapBOToModel(
			BOCountryRegionCurrency boCountryRegionCurrency)
		{
			var model = new ApiCountryRegionCurrencyResponseModel();

			model.SetProperties(boCountryRegionCurrency.CountryRegionCode, boCountryRegionCurrency.CurrencyCode, boCountryRegionCurrency.ModifiedDate);

			return model;
		}

		public virtual List<ApiCountryRegionCurrencyResponseModel> MapBOToModel(
			List<BOCountryRegionCurrency> items)
		{
			List<ApiCountryRegionCurrencyResponseModel> response = new List<ApiCountryRegionCurrencyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>daa153aeae7e985b857fb09dbcea4ff2</Hash>
</Codenesium>*/