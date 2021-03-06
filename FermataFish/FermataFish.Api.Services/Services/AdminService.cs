using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper boladminMapper,
			IDALAdminMapper daladminMapper
			)
			: base(logger,
			       adminRepository,
			       adminModelValidator,
			       boladminMapper,
			       daladminMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4dc8f21763b4fd61a9812bf1cef633d3</Hash>
</Codenesium>*/