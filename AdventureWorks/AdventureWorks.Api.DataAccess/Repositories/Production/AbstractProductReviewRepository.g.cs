using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductReviewRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductReviewRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductReview>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductReview> Get(int productReviewID)
		{
			return await this.GetById(productReviewID);
		}

		public async virtual Task<ProductReview> Create(ProductReview item)
		{
			this.Context.Set<ProductReview>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductReview item)
		{
			var entity = this.Context.Set<ProductReview>().Local.FirstOrDefault(x => x.ProductReviewID == item.ProductReviewID);
			if (entity == null)
			{
				this.Context.Set<ProductReview>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productReviewID)
		{
			ProductReview record = await this.GetById(productReviewID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductReview>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<ProductReview>> ByProductIDReviewerName(int productID, string reviewerName)
		{
			var records = await this.Where(x => x.ProductID == productID && x.ReviewerName == reviewerName);

			return records;
		}

		protected async Task<List<ProductReview>> Where(
			Expression<Func<ProductReview, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductReview, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductReviewID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductReview>();
			}
			else
			{
				return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductReview>();
			}
		}

		private async Task<ProductReview> GetById(int productReviewID)
		{
			List<ProductReview> records = await this.Where(x => x.ProductReviewID == productReviewID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d9467fc1e32cd17b568aeb689f8c7985</Hash>
</Codenesium>*/