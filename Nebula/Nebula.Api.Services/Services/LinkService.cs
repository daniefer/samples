using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class LinkService : AbstractLinkService, ILinkService
	{
		public LinkService(
			ILogger<ILinkRepository> logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper bollinkMapper,
			IDALLinkMapper dallinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper
			)
			: base(logger,
			       linkRepository,
			       linkModelValidator,
			       bollinkMapper,
			       dallinkMapper,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e2cfd002133ab4245562ffb3f746676a</Hash>
</Codenesium>*/