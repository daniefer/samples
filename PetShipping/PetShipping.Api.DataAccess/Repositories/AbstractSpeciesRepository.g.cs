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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractSpeciesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpeciesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Species>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Species> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Species> Create(Species item)
		{
			this.Context.Set<Species>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Species item)
		{
			var entity = this.Context.Set<Species>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Species>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			Species record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Species>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Breed>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Breed>().Where(x => x.SpeciesId == speciesId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Breed>();
		}

		protected async Task<List<Species>> Where(
			Expression<Func<Species, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Species, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Species>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Species>();
			}
			else
			{
				return await this.Context.Set<Species>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Species>();
			}
		}

		private async Task<Species> GetById(int id)
		{
			List<Species> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b12163993f74d44f9f0d69b7281db713</Hash>
</Codenesium>*/