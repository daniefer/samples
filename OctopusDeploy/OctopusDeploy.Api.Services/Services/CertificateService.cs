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
        public partial class CertificateService : AbstractCertificateService, ICertificateService
        {
                public CertificateService(
                        ILogger<ICertificateRepository> logger,
                        ICertificateRepository certificateRepository,
                        IApiCertificateRequestModelValidator certificateModelValidator,
                        IBOLCertificateMapper bolcertificateMapper,
                        IDALCertificateMapper dalcertificateMapper
                        )
                        : base(logger,
                               certificateRepository,
                               certificateModelValidator,
                               bolcertificateMapper,
                               dalcertificateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3f3216d346d05e563ff889fee941a922</Hash>
</Codenesium>*/