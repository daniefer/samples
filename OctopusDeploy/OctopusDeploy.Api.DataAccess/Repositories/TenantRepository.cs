using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class TenantRepository : AbstractTenantRepository, ITenantRepository
	{
		public TenantRepository(
			ILogger<TenantRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5c0fc6b27c4a5a514904653c19686924</Hash>
</Codenesium>*/