using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class BusinessEntityAddressService : AbstractBusinessEntityAddressService, IBusinessEntityAddressService
        {
                public BusinessEntityAddressService(
                        ILogger<IBusinessEntityAddressRepository> logger,
                        IBusinessEntityAddressRepository businessEntityAddressRepository,
                        IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
                        IBOLBusinessEntityAddressMapper bolbusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalbusinessEntityAddressMapper
                        )
                        : base(logger,
                               businessEntityAddressRepository,
                               businessEntityAddressModelValidator,
                               bolbusinessEntityAddressMapper,
                               dalbusinessEntityAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8cf42cad94c33546d1b6e8626bad70a2</Hash>
</Codenesium>*/