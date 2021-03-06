using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class CertificateRepository : AbstractCertificateRepository, ICertificateRepository
	{
		public CertificateRepository(
			ILogger<CertificateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b01e0170f39b2c78424597733dbca6fe</Hash>
</Codenesium>*/