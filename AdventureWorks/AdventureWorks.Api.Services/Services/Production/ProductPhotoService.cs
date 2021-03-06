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
	public partial class ProductPhotoService : AbstractProductPhotoService, IProductPhotoService
	{
		public ProductPhotoService(
			ILogger<IProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolproductPhotoMapper,
			IDALProductPhotoMapper dalproductPhotoMapper,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper
			)
			: base(logger,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       bolproductPhotoMapper,
			       dalproductPhotoMapper,
			       bolProductProductPhotoMapper,
			       dalProductProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>23c822c0e33ef03c12b228989e4592ce</Hash>
</Codenesium>*/