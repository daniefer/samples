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
	public abstract class AbstractLocationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLocationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Location>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Location> Get(short locationID)
		{
			return await this.GetById(locationID);
		}

		public async virtual Task<Location> Create(Location item)
		{
			this.Context.Set<Location>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Location item)
		{
			var entity = this.Context.Set<Location>().Local.FirstOrDefault(x => x.LocationID == item.LocationID);
			if (entity == null)
			{
				this.Context.Set<Location>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			short locationID)
		{
			Location record = await this.GetById(locationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Location>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Location> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async virtual Task<List<ProductInventory>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductInventory>().Where(x => x.LocationID == locationID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductInventory>();
		}

		public async virtual Task<List<WorkOrderRouting>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<WorkOrderRouting>().Where(x => x.LocationID == locationID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrderRouting>();
		}

		protected async Task<List<Location>> Where(
			Expression<Func<Location, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Location, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.LocationID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Location>();
			}
			else
			{
				return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Location>();
			}
		}

		private async Task<Location> GetById(short locationID)
		{
			List<Location> records = await this.Where(x => x.LocationID == locationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ef4a4fa64d35fb63064343fcdcb4b1f9</Hash>
</Codenesium>*/