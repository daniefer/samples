using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class BucketRepository: AbstractBucketRepository, IBucketRepository
	{
		public BucketRepository(ILogger<BucketRepository> logger,
		                        ApplicationContext context) : base(logger,context)
		{}

		protected override List<Bucket> SearchLinqEF(Expression<Func<Bucket, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Bucket>();
			}
			else
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
			}
		}

		protected override List<Bucket> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Bucket>();
			}
			else
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>fbaa38036e448ca2c9f2979773585436</Hash>
</Codenesium>*/