using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class ApiKeyService : AbstractApiKeyService, IApiKeyService
	{
		public ApiKeyService(
			ILogger<IApiKeyRepository> logger,
			IApiKeyRepository apiKeyRepository,
			IApiApiKeyRequestModelValidator apiKeyModelValidator,
			IBOLApiKeyMapper bolapiKeyMapper,
			IDALApiKeyMapper dalapiKeyMapper
			)
			: base(logger,
			       apiKeyRepository,
			       apiKeyModelValidator,
			       bolapiKeyMapper,
			       dalapiKeyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5836353bee84766c453510a8d020470b</Hash>
</Codenesium>*/