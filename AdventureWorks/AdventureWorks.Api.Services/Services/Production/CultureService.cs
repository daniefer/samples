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
	public partial class CultureService : AbstractCultureService, ICultureService
	{
		public CultureService(
			ILogger<ICultureRepository> logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolcultureMapper,
			IDALCultureMapper dalcultureMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper
			)
			: base(logger,
			       cultureRepository,
			       cultureModelValidator,
			       bolcultureMapper,
			       dalcultureMapper,
			       bolProductModelProductDescriptionCultureMapper,
			       dalProductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>983af1c82698df33dc89ffa6ead48d1d</Hash>
</Codenesium>*/