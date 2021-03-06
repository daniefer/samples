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

namespace OctopusDeployNS.Api.DataAccess
{
	public abstract class AbstractMachineRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractMachineRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Machine> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Machine> Create(Machine item)
		{
			this.Context.Set<Machine>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Machine item)
		{
			var entity = this.Context.Set<Machine>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Machine>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string id)
		{
			Machine record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Machine>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Machine> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async Task<List<Machine>> ByMachinePolicyId(string machinePolicyId)
		{
			var records = await this.Where(x => x.MachinePolicyId == machinePolicyId);

			return records;
		}

		protected async Task<List<Machine>> Where(
			Expression<Func<Machine, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Machine, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Machine>();
			}
			else
			{
				return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Machine>();
			}
		}

		private async Task<Machine> GetById(string id)
		{
			List<Machine> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>782e41774c56a48ad32f0c54f740be13</Hash>
</Codenesium>*/