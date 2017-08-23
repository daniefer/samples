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
	public abstract class AbstractChainRepository
	{
		DbContext _context;
		ILogger _logger;

		public AbstractChainRepository(ILogger logger,
		                               DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int chainStatusId,
		                          Guid externalId,
		                          int id,
		                          string name,
		                          int teamId)
		{
			var record = new Chain ();

			MapPOCOToEF(chainStatusId,
			            externalId,
			            id,
			            name,
			            teamId, record);

			this._context.Set<Chain>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int chainStatusId,
		                           Guid externalId,
		                           int id,
		                           string name,
		                           int teamId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(chainStatusId,
				            externalId,
				            id,
				            name,
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
				this._context.Set<Chain>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		private List<Chain> SearchLinqEF(Expression<Func<Chain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Chain>();
			}
			else
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
			}
		}

		private List<Chain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Chain>();
			}
			else
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
			}
		}

		public virtual void GetWhere(Expression<Func<Chain, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Chain, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Chain> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Chain> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int chainStatusId,
		                               Guid externalId,
		                               int id,
		                               string name,
		                               int teamId, Chain   efChain)
		{
			efChain.chainStatusId = chainStatusId;
			efChain.externalId = externalId;
			efChain.id = id;
			efChain.name = name;
			efChain.teamId = teamId;
		}

		public static void MapEFToPOCO(Chain efChain,Response response)
		{
			if(efChain == null)
			{
				return;
			}
			response.AddChain(new POCOChain()
			{
				ExternalId = efChain.externalId,
				Id = efChain.id.ToInt(),
				Name = efChain.name,

				ChainStatusId = new ReferenceEntity<int>(efChain.chainStatusId,
				                                         "ChainStatus"),
				TeamId = new ReferenceEntity<int>(efChain.teamId,
				                                  "Team"),
			}
			                  );

			ChainStatusRepository.MapEFToPOCO(efChain.ChainStatus, response);
			TeamRepository.MapEFToPOCO(efChain.Team, response);
		}
	}
}

/*<Codenesium>
    <Hash>7d4dc7588dca69678ad74e7c1fefa72b</Hash>
</Codenesium>*/