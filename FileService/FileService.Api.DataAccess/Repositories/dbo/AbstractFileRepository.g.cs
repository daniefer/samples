using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractFileRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALFileMapper Mapper { get; }

		public AbstractFileRepository(
			IDALFileMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOFile>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOFile> Get(int id)
		{
			File record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOFile> Create(
			DTOFile dto)
		{
			File record = new File();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<File>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOFile dto)
		{
			File record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			File record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<File>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOFile>> Where(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOFile> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOFile>> SearchLinqDTO(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOFile> response = new List<DTOFile>();
			List<File> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<File>> SearchLinqEF(Expression<Func<File, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(File.Id)} ASC";
			}
			return await this.Context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<File>();
		}

		private async Task<List<File>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(File.Id)} ASC";
			}

			return await this.Context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<File>();
		}

		private async Task<File> GetById(int id)
		{
			List<File> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fa5ddd65e74adf348c667a10d7b566c4</Hash>
</Codenesium>*/