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
	public abstract class AbstractPurchaseOrderHeaderService : AbstractService
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;

		private IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator;

		private IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper;

		private IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper;

		private IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper;

		private IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper;

		private ILogger logger;

		public AbstractPurchaseOrderHeaderService(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper,
			IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper)
			: base()
		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.bolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.dalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.bolPurchaseOrderDetailMapper = bolPurchaseOrderDetailMapper;
			this.dalPurchaseOrderDetailMapper = dalPurchaseOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.purchaseOrderHeaderRepository.All(limit, offset);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID)
		{
			var record = await this.purchaseOrderHeaderRepository.Get(purchaseOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPurchaseOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.purchaseOrderHeaderRepository.Create(this.dalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model)
		{
			var validationResult = await this.purchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolPurchaseOrderHeaderMapper.MapModelToBO(purchaseOrderID, model);
				await this.purchaseOrderHeaderRepository.Update(this.dalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.purchaseOrderHeaderRepository.Get(purchaseOrderID);

				return new UpdateResponse<ApiPurchaseOrderHeaderResponseModel>(this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPurchaseOrderHeaderResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));
			if (response.Success)
			{
				await this.purchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}

			return response;
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByEmployeeID(int employeeID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.ByEmployeeID(employeeID);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByVendorID(int vendorID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.ByVendorID(vendorID);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderDetail> records = await this.purchaseOrderHeaderRepository.PurchaseOrderDetails(purchaseOrderID, limit, offset);

			return this.bolPurchaseOrderDetailMapper.MapBOToModel(this.dalPurchaseOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>20de0b246c68a9283ec005fa32e5e9d2</Hash>
</Codenesium>*/