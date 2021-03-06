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
	public partial class EmailAddressService : AbstractEmailAddressService, IEmailAddressService
	{
		public EmailAddressService(
			ILogger<IEmailAddressRepository> logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper bolemailAddressMapper,
			IDALEmailAddressMapper dalemailAddressMapper
			)
			: base(logger,
			       emailAddressRepository,
			       emailAddressModelValidator,
			       bolemailAddressMapper,
			       dalemailAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b502a131efe8a488006251e8758aa6b1</Hash>
</Codenesium>*/