using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		Task<SpecialOfferProduct> Create(SpecialOfferProduct item);

		Task Update(SpecialOfferProduct item);

		Task Delete(int specialOfferID);

		Task<SpecialOfferProduct> Get(int specialOfferID);

		Task<List<SpecialOfferProduct>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SpecialOfferProduct>> ByProductID(int productID);

		Task<List<SalesOrderDetail>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0);

		Task<SpecialOffer> GetSpecialOffer(int specialOfferID);
	}
}

/*<Codenesium>
    <Hash>f58f62c469f52e2d1f1e66ad92ab8f0c</Hash>
</Codenesium>*/