using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractSaleService : AbstractService
	{
		private ISaleRepository saleRepository;

		private IApiSaleRequestModelValidator saleModelValidator;

		private IBOLSaleMapper bolSaleMapper;

		private IDALSaleMapper dalSaleMapper;

		private ILogger logger;

		public AbstractSaleService(
			ILogger logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.bolSaleMapper = bolSaleMapper;
			this.dalSaleMapper = dalSaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.saleRepository.All(limit, offset);

			return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleResponseModel> Get(int id)
		{
			var record = await this.saleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model)
		{
			CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSaleMapper.MapModelToBO(default(int), model);
				var record = await this.saleRepository.Create(this.dalSaleMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleResponseModel>> Update(
			int id,
			ApiSaleRequestModel model)
		{
			var validationResult = await this.saleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSaleMapper.MapModelToBO(id, model);
				await this.saleRepository.Update(this.dalSaleMapper.MapBOToEF(bo));

				var record = await this.saleRepository.Get(id);

				return new UpdateResponse<ApiSaleResponseModel>(this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSaleResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.saleRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ce7a5b22137d287b3f06817c670977b7</Hash>
</Codenesium>*/