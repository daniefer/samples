using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class ProxyService : AbstractProxyService, IProxyService
        {
                public ProxyService(
                        ILogger<IProxyRepository> logger,
                        IProxyRepository proxyRepository,
                        IApiProxyRequestModelValidator proxyModelValidator,
                        IBOLProxyMapper bolproxyMapper,
                        IDALProxyMapper dalproxyMapper
                        )
                        : base(logger,
                               proxyRepository,
                               proxyModelValidator,
                               bolproxyMapper,
                               dalproxyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>05ffa5cc98ea81eb901a100923f339ba</Hash>
</Codenesium>*/