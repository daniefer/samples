using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesPersonRepository
        {
                Task<SalesPerson> Create(SalesPerson item);

                Task Update(SalesPerson item);

                Task Delete(int businessEntityID);

                Task<SalesPerson> Get(int businessEntityID);

                Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0);

                Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<Store>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0);

                Task<SalesTerritory> GetSalesTerritory(int? territoryID);
        }
}

/*<Codenesium>
    <Hash>5f57949b8280417e5057e191dd4be799</Hash>
</Codenesium>*/