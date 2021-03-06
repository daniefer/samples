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

namespace StackOverflowNS.Api.DataAccess
{
	public abstract class AbstractVoteTypesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVoteTypesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VoteTypes>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<VoteTypes> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VoteTypes> Create(VoteTypes item)
		{
			this.Context.Set<VoteTypes>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VoteTypes item)
		{
			var entity = this.Context.Set<VoteTypes>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VoteTypes>().Attach(item);
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
			VoteTypes record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VoteTypes>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<VoteTypes>> Where(
			Expression<Func<VoteTypes, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VoteTypes, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<VoteTypes>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VoteTypes>();
			}
			else
			{
				return await this.Context.Set<VoteTypes>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<VoteTypes>();
			}
		}

		private async Task<VoteTypes> GetById(int id)
		{
			List<VoteTypes> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2e69ce9b90570feb9c6d7a4561f347c0</Hash>
</Codenesium>*/