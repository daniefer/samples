using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractAddressTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAddressTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			AddressTypeModel model)
		{
			EFAddressType record = new EFAddressType();

			this.Mapper.AddressTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFAddressType>().Add(record);
			this.Context.SaveChanges();
			return record.AddressTypeID;
		}

		public virtual void Update(
			int addressTypeID,
			AddressTypeModel model)
		{
			EFAddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressTypeID}");
			}
			else
			{
				this.Mapper.AddressTypeMapModelToEF(
					addressTypeID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int addressTypeID)
		{
			EFAddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFAddressType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int addressTypeID)
		{
			return this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID);
		}

		public virtual POCOAddressType GetByIdDirect(int addressTypeID)
		{
			return this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID).AddressTypes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).AddressTypes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAddressType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AddressTypeMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAddressType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AddressTypeMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddressType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>5792e745add56093a723c341a31978ed</Hash>
</Codenesium>*/