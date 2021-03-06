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
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolcustomerMapper,
			IDALCustomerMapper dalcustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
			)
			: base(logger,
			       customerRepository,
			       customerModelValidator,
			       bolcustomerMapper,
			       dalcustomerMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f893736f2d0d196499abc5ffa8ae78f</Hash>
</Codenesium>*/