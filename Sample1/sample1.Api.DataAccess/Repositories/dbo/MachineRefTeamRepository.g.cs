using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using sample1NS.Api.Contracts;

namespace sample1NS.Api.DataAccess
{
	public abstract class AbstractMachineRefTeamRepository
	{
		DbContext _context;
		ILogger _logger;

		public AbstractMachineRefTeamRepository(ILogger logger,
		                                        DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int id,
		                          int machineId,
		                          int teamId)
		{
			var record = new MachineRefTeam ();

			MapPOCOToEF(id,
			            machineId,
			            teamId, record);

			this._context.Set<MachineRefTeam>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id,
		                           int machineId,
		                           int teamId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,
				            machineId,
				            teamId, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<MachineRefTeam>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		private List<MachineRefTeam> SearchLinqEF(Expression<Func<MachineRefTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
			else
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
		}

		private List<MachineRefTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
			else
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
		}

		public virtual void GetWhere(Expression<Func<MachineRefTeam, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<MachineRefTeam, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<MachineRefTeam> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<MachineRefTeam> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id,
		                               int machineId,
		                               int teamId, MachineRefTeam   efMachineRefTeam)
		{
			efMachineRefTeam.id = id;
			efMachineRefTeam.machineId = machineId;
			efMachineRefTeam.teamId = teamId;
		}

		public static void MapEFToPOCO(MachineRefTeam efMachineRefTeam,Response response)
		{
			if(efMachineRefTeam == null)
			{
				return;
			}
			response.AddMachineRefTeam(new POCOMachineRefTeam()
			{
				Id = efMachineRefTeam.id.ToInt(),

				MachineId = new ReferenceEntity<int>(efMachineRefTeam.machineId,
				                                     "Machine"),
				TeamId = new ReferenceEntity<int>(efMachineRefTeam.teamId,
				                                  "Team"),
			}
			                           );

			MachineRepository.MapEFToPOCO(efMachineRefTeam.Machine, response);
			TeamRepository.MapEFToPOCO(efMachineRefTeam.Team, response);
		}
	}
}

/*<Codenesium>
    <Hash>66ad301e6bc96d7a9bce8227d990a988</Hash>
</Codenesium>*/