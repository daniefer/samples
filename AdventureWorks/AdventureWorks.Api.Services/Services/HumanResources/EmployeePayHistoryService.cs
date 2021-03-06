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
	public partial class EmployeePayHistoryService : AbstractEmployeePayHistoryService, IEmployeePayHistoryService
	{
		public EmployeePayHistoryService(
			ILogger<IEmployeePayHistoryRepository> logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper bolemployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper
			)
			: base(logger,
			       employeePayHistoryRepository,
			       employeePayHistoryModelValidator,
			       bolemployeePayHistoryMapper,
			       dalemployeePayHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d754077d2f3735ac9c27f14bdf1526b0</Hash>
</Codenesium>*/