using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductPhotoRepository: AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(ILogger<ProductPhotoRepository> logger,
		                              ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this.context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}

		protected override List<EFProductPhoto> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this.context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2b419e3638684f94648bf6ff5672d4ff</Hash>
</Codenesium>*/