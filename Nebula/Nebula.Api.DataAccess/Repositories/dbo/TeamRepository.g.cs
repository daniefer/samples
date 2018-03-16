using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractTeamRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractTeamRepository(ILogger logger,
		                              ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          int organizationId)
		{
			var record = new Team ();

			MapPOCOToEF(0, name,
			            organizationId, record);

			this._context.Set<Team>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name,
		                           int organizationId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            organizationId, record);
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
				this._context.Set<Team>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Team> SearchLinqEF(Expression<Func<Team, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Team> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Team, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Team, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Team> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Team> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               int organizationId, Team   efTeam)
		{
			efTeam.id = id;
			efTeam.name = name;
			efTeam.organizationId = organizationId;
		}

		public static void MapEFToPOCO(Team efTeam,Response response)
		{
			if(efTeam == null)
			{
				return;
			}
			response.AddTeam(new POCOTeam()
			{
				Id = efTeam.id.ToInt(),
				Name = efTeam.name,

				OrganizationId = new ReferenceEntity<int>(efTeam.organizationId,
				                                          "Organizations"),
			});

			OrganizationRepository.MapEFToPOCO(efTeam.OrganizationRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>30611750911ebd6b861f627d9498e165</Hash>
</Codenesium>*/