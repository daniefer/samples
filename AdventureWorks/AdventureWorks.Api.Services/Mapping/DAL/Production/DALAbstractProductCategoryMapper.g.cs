using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductCategoryMapper
	{
		public virtual ProductCategory MapBOToEF(
			BOProductCategory bo)
		{
			ProductCategory efProductCategory = new ProductCategory();
			efProductCategory.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.ProductCategoryID,
				bo.Rowguid);
			return efProductCategory;
		}

		public virtual BOProductCategory MapEFToBO(
			ProductCategory ef)
		{
			var bo = new BOProductCategory();

			bo.SetProperties(
				ef.ProductCategoryID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOProductCategory> MapEFToBO(
			List<ProductCategory> records)
		{
			List<BOProductCategory> response = new List<BOProductCategory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e2c01e9784c2cd64f7deb12a73cbe114</Hash>
</Codenesium>*/