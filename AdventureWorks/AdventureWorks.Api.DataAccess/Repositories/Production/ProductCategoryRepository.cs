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
	public class ProductCategoryRepository: AbstractProductCategoryRepository, IProductCategoryRepository
	{
		public ProductCategoryRepository(ILogger<ProductCategoryRepository> logger,
		                                 ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}

		protected override List<EFProductCategory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy("ProductCategoryID ASC").Skip(skip).Take(take).ToList<EFProductCategory>();
			}
			else
			{
				return this.context.Set<EFProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a2e4a75a246fe8fef2511c36add0ce2c</Hash>
</Codenesium>*/