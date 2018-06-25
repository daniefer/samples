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
        public partial class CreditCardService : AbstractCreditCardService, ICreditCardService
        {
                public CreditCardService(
                        ILogger<ICreditCardRepository> logger,
                        ICreditCardRepository creditCardRepository,
                        IApiCreditCardRequestModelValidator creditCardModelValidator,
                        IBOLCreditCardMapper bolcreditCardMapper,
                        IDALCreditCardMapper dalcreditCardMapper,
                        IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalPersonCreditCardMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        )
                        : base(logger,
                               creditCardRepository,
                               creditCardModelValidator,
                               bolcreditCardMapper,
                               dalcreditCardMapper,
                               bolPersonCreditCardMapper,
                               dalPersonCreditCardMapper,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e81ea5c93586629c42b510992abdc7bc</Hash>
</Codenesium>*/