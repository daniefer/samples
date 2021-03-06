using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCityService : AbstractService
	{
		private ICityRepository cityRepository;

		private IApiCityRequestModelValidator cityModelValidator;

		private IBOLCityMapper bolCityMapper;

		private IDALCityMapper dalCityMapper;

		private IBOLEventMapper bolEventMapper;

		private IDALEventMapper dalEventMapper;

		private ILogger logger;

		public AbstractCityService(
			ILogger logger,
			ICityRepository cityRepository,
			IApiCityRequestModelValidator cityModelValidator,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.cityRepository = cityRepository;
			this.cityModelValidator = cityModelValidator;
			this.bolCityMapper = bolCityMapper;
			this.dalCityMapper = dalCityMapper;
			this.bolEventMapper = bolEventMapper;
			this.dalEventMapper = dalEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCityResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.cityRepository.All(limit, offset);

			return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCityResponseModel> Get(int id)
		{
			var record = await this.cityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCityResponseModel>> Create(
			ApiCityRequestModel model)
		{
			CreateResponse<ApiCityResponseModel> response = new CreateResponse<ApiCityResponseModel>(await this.cityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCityMapper.MapModelToBO(default(int), model);
				var record = await this.cityRepository.Create(this.dalCityMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCityResponseModel>> Update(
			int id,
			ApiCityRequestModel model)
		{
			var validationResult = await this.cityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCityMapper.MapModelToBO(id, model);
				await this.cityRepository.Update(this.dalCityMapper.MapBOToEF(bo));

				var record = await this.cityRepository.Get(id);

				return new UpdateResponse<ApiCityResponseModel>(this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCityResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.cityModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.cityRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiCityResponseModel>> ByProvinceId(int provinceId)
		{
			List<City> records = await this.cityRepository.ByProvinceId(provinceId);

			return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventResponseModel>> Events(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.cityRepository.Events(cityId, limit, offset);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7164c15dce52c3cb45d1692a54e2b669</Hash>
</Codenesium>*/