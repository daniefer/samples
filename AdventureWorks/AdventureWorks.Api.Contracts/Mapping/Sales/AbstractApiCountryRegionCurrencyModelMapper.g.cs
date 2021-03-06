using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCountryRegionCurrencyModelMapper
	{
		public virtual ApiCountryRegionCurrencyResponseModel MapRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel request)
		{
			var response = new ApiCountryRegionCurrencyResponseModel();
			response.SetProperties(countryRegionCode,
			                       request.CurrencyCode,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiCountryRegionCurrencyRequestModel MapResponseToRequest(
			ApiCountryRegionCurrencyResponseModel response)
		{
			var request = new ApiCountryRegionCurrencyRequestModel();
			request.SetProperties(
				response.CurrencyCode,
				response.ModifiedDate);
			return request;
		}

		public JsonPatchDocument<ApiCountryRegionCurrencyRequestModel> CreatePatch(ApiCountryRegionCurrencyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryRegionCurrencyRequestModel>();
			patch.Replace(x => x.CurrencyCode, model.CurrencyCode);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>bb799ab6b7bc20fa1524aea82e66993f</Hash>
</Codenesium>*/