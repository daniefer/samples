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
        public partial class AddressTypeService : AbstractAddressTypeService, IAddressTypeService
        {
                public AddressTypeService(
                        ILogger<IAddressTypeRepository> logger,
                        IAddressTypeRepository addressTypeRepository,
                        IApiAddressTypeRequestModelValidator addressTypeModelValidator,
                        IBOLAddressTypeMapper boladdressTypeMapper,
                        IDALAddressTypeMapper daladdressTypeMapper,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
                        )
                        : base(logger,
                               addressTypeRepository,
                               addressTypeModelValidator,
                               boladdressTypeMapper,
                               daladdressTypeMapper,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>03ff4c274632ca91a3ffe9915ef940b9</Hash>
</Codenesium>*/