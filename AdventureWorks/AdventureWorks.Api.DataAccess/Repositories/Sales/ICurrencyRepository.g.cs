using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		Task<Currency> Create(Currency item);

		Task Update(Currency item);

		Task Delete(string currencyCode);

		Task<Currency> Get(string currencyCode);

		Task<List<Currency>> All(int limit = int.MaxValue, int offset = 0);

		Task<Currency> ByName(string name);

		Task<List<CountryRegionCurrency>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);

		Task<List<CurrencyRate>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8f0e3deb8696e2fd6e56d1c4575299ac</Hash>
</Codenesium>*/