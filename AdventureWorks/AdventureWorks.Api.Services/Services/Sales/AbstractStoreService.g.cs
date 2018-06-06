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
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractStoreService: AbstractService
	{
		private IStoreRepository storeRepository;
		private IApiStoreRequestModelValidator storeModelValidator;
		private IBOLStoreMapper bolStoreMapper;
		private IDALStoreMapper dalStoreMapper;
		private ILogger logger;

		public AbstractStoreService(
			ILogger logger,
			IStoreRepository storeRepository,
			IApiStoreRequestModelValidator storeModelValidator,
			IBOLStoreMapper bolstoreMapper,
			IDALStoreMapper dalstoreMapper)
			: base()

		{
			this.storeRepository = storeRepository;
			this.storeModelValidator = storeModelValidator;
			this.bolStoreMapper = bolstoreMapper;
			this.dalStoreMapper = dalstoreMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStoreResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.storeRepository.All(skip, take, orderClause);

			return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStoreResponseModel> Get(int businessEntityID)
		{
			var record = await storeRepository.Get(businessEntityID);

			return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStoreResponseModel>> Create(
			ApiStoreRequestModel model)
		{
			CreateResponse<ApiStoreResponseModel> response = new CreateResponse<ApiStoreResponseModel>(await this.storeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolStoreMapper.MapModelToBO(default (int), model);
				var record = await this.storeRepository.Create(this.dalStoreMapper.MapBOToEF(bo));

				response.SetRecord(this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiStoreRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.bolStoreMapper.MapModelToBO(businessEntityID, model);
				await this.storeRepository.Update(this.dalStoreMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.storeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiStoreResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<Store> records = await this.storeRepository.GetSalesPersonID(salesPersonID);

			return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
		}
		public async Task<List<ApiStoreResponseModel>> GetDemographics(string demographics)
		{
			List<Store> records = await this.storeRepository.GetDemographics(demographics);

			return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6a8a580632ff879b16ece75e53249c64</Hash>
</Codenesium>*/