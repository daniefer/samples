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
	public partial class TransactionHistoryArchiveService : AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
	{
		public TransactionHistoryArchiveService(
			ILogger<ITransactionHistoryArchiveRepository> logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper boltransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper daltransactionHistoryArchiveMapper
			)
			: base(logger,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       boltransactionHistoryArchiveMapper,
			       daltransactionHistoryArchiveMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b7ed1bdc40a34335f683c2fe848ef263</Hash>
</Codenesium>*/