using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractSpecialOfferProductRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALSpecialOfferProductMapper Mapper { get; }

		public AbstractSpecialOfferProductRepository(
			IDALSpecialOfferProductMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSpecialOfferProduct> Get(int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSpecialOfferProduct> Create(
			DTOSpecialOfferProduct dto)
		{
			SpecialOfferProduct record = new SpecialOfferProduct();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SpecialOfferProduct>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int specialOfferID,
			DTOSpecialOfferProduct dto)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					specialOfferID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOfferProduct>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOSpecialOfferProduct>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<DTOSpecialOfferProduct>> Where(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSpecialOfferProduct> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSpecialOfferProduct>> SearchLinqDTO(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSpecialOfferProduct> response = new List<DTOSpecialOfferProduct>();
			List<SpecialOfferProduct> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEF(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}
			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}

			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<SpecialOfferProduct> GetById(int specialOfferID)
		{
			List<SpecialOfferProduct> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>43906e58d2d2f676c38630645cc97e1f</Hash>
</Codenesium>*/