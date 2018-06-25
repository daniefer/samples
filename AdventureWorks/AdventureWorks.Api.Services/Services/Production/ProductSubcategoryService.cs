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
        public partial class ProductSubcategoryService : AbstractProductSubcategoryService, IProductSubcategoryService
        {
                public ProductSubcategoryService(
                        ILogger<IProductSubcategoryRepository> logger,
                        IProductSubcategoryRepository productSubcategoryRepository,
                        IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
                        IBOLProductSubcategoryMapper bolproductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalproductSubcategoryMapper,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper
                        )
                        : base(logger,
                               productSubcategoryRepository,
                               productSubcategoryModelValidator,
                               bolproductSubcategoryMapper,
                               dalproductSubcategoryMapper,
                               bolProductMapper,
                               dalProductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>31a1fb27e91f837706c01be688922bba</Hash>
</Codenesium>*/