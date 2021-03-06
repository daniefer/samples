using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ICurrencyRateService
	{
		Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
			ApiCurrencyRateRequestModel model);

		Task<UpdateResponse<ApiCurrencyRateResponseModel>> Update(int currencyRateID,
		                                                           ApiCurrencyRateRequestModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		Task<ApiCurrencyRateResponseModel> Get(int currencyRateID);

		Task<List<ApiCurrencyRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCurrencyRateResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

		Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>77226c1b6520a3a61545ccebfed3009c</Hash>
</Codenesium>*/