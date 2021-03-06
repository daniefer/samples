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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractMachineRefTeamRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractMachineRefTeamRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<MachineRefTeam>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<MachineRefTeam> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<MachineRefTeam> Create(MachineRefTeam item)
		{
			this.Context.Set<MachineRefTeam>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(MachineRefTeam item)
		{
			var entity = this.Context.Set<MachineRefTeam>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<MachineRefTeam>().Attach(item);
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
			MachineRefTeam record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<MachineRefTeam>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Machine> GetMachine(int machineId)
		{
			return await this.Context.Set<Machine>().SingleOrDefaultAsync(x => x.Id == machineId);
		}

		public async virtual Task<Team> GetTeam(int teamId)
		{
			return await this.Context.Set<Team>().SingleOrDefaultAsync(x => x.Id == teamId);
		}

		protected async Task<List<MachineRefTeam>> Where(
			Expression<Func<MachineRefTeam, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<MachineRefTeam, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<MachineRefTeam>();
			}
			else
			{
				return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<MachineRefTeam>();
			}
		}

		private async Task<MachineRefTeam> GetById(int id)
		{
			List<MachineRefTeam> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a1d93ca9802bb393c3be2e90a2aa9b23</Hash>
</Codenesium>*/