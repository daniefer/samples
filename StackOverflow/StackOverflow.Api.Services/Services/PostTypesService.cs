using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class PostTypesService : AbstractPostTypesService, IPostTypesService
	{
		public PostTypesService(
			ILogger<IPostTypesRepository> logger,
			IPostTypesRepository postTypesRepository,
			IApiPostTypesRequestModelValidator postTypesModelValidator,
			IBOLPostTypesMapper bolpostTypesMapper,
			IDALPostTypesMapper dalpostTypesMapper
			)
			: base(logger,
			       postTypesRepository,
			       postTypesModelValidator,
			       bolpostTypesMapper,
			       dalpostTypesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>12de39b16e88c244b38137240825ad3b</Hash>
</Codenesium>*/