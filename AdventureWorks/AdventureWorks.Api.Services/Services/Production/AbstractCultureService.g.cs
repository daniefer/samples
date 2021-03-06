using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCultureService : AbstractService
	{
		private ICultureRepository cultureRepository;

		private IApiCultureRequestModelValidator cultureModelValidator;

		private IBOLCultureMapper bolCultureMapper;

		private IDALCultureMapper dalCultureMapper;

		private IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper;

		private IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper;

		private ILogger logger;

		public AbstractCultureService(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolCultureMapper,
			IDALCultureMapper dalCultureMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base()
		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.bolCultureMapper = bolCultureMapper;
			this.dalCultureMapper = dalCultureMapper;
			this.bolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
			this.dalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCultureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.cultureRepository.All(limit, offset);

			return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCultureResponseModel> Get(string cultureID)
		{
			var record = await this.cultureRepository.Get(cultureID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> response = new CreateResponse<ApiCultureResponseModel>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCultureMapper.MapModelToBO(default(string), model);
				var record = await this.cultureRepository.Create(this.dalCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCultureResponseModel>> Update(
			string cultureID,
			ApiCultureRequestModel model)
		{
			var validationResult = await this.cultureModelValidator.ValidateUpdateAsync(cultureID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCultureMapper.MapModelToBO(cultureID, model);
				await this.cultureRepository.Update(this.dalCultureMapper.MapBOToEF(bo));

				var record = await this.cultureRepository.Get(cultureID);

				return new UpdateResponse<ApiCultureResponseModel>(this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCultureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateDeleteAsync(cultureID));
			if (response.Success)
			{
				await this.cultureRepository.Delete(cultureID);
			}

			return response;
		}

		public async Task<ApiCultureResponseModel> ByName(string name)
		{
			Culture record = await this.cultureRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModelProductDescriptionCulture> records = await this.cultureRepository.ProductModelProductDescriptionCultures(cultureID, limit, offset);

			return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9a5a76388d69d11049e75b3fdbdfaf21</Hash>
</Codenesium>*/