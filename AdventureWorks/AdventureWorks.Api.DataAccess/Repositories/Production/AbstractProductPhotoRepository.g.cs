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
	public abstract class AbstractProductPhotoRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductPhotoRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductPhoto>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductPhoto> Get(int productPhotoID)
		{
			return await this.GetById(productPhotoID);
		}

		public async virtual Task<ProductPhoto> Create(ProductPhoto item)
		{
			this.Context.Set<ProductPhoto>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductPhoto item)
		{
			var entity = this.Context.Set<ProductPhoto>().Local.FirstOrDefault(x => x.ProductPhotoID == item.ProductPhotoID);
			if (entity == null)
			{
				this.Context.Set<ProductPhoto>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productPhotoID)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductPhoto>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<ProductProductPhoto>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductProductPhoto>().Where(x => x.ProductPhotoID == productPhotoID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
		}

		protected async Task<List<ProductPhoto>> Where(
			Expression<Func<ProductPhoto, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductPhoto, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductPhotoID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductPhoto>();
			}
			else
			{
				return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductPhoto>();
			}
		}

		private async Task<ProductPhoto> GetById(int productPhotoID)
		{
			List<ProductPhoto> records = await this.Where(x => x.ProductPhotoID == productPhotoID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d21701db27d20a4db6342fc7998fa712</Hash>
</Codenesium>*/