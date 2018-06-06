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
	public abstract class AbstractTransactionHistoryService: AbstractService
	{
		private ITransactionHistoryRepository transactionHistoryRepository;
		private IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator;
		private IBOLTransactionHistoryMapper bolTransactionHistoryMapper;
		private IDALTransactionHistoryMapper dalTransactionHistoryMapper;
		private ILogger logger;

		public AbstractTransactionHistoryService(
			ILogger logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper boltransactionHistoryMapper,
			IDALTransactionHistoryMapper daltransactionHistoryMapper)
			: base()

		{
			this.transactionHistoryRepository = transactionHistoryRepository;
			this.transactionHistoryModelValidator = transactionHistoryModelValidator;
			this.bolTransactionHistoryMapper = boltransactionHistoryMapper;
			this.dalTransactionHistoryMapper = daltransactionHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.transactionHistoryRepository.All(skip, take, orderClause);

			return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> Get(int transactionID)
		{
			var record = await transactionHistoryRepository.Get(transactionID);

			return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
			ApiTransactionHistoryRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryResponseModel> response = new CreateResponse<ApiTransactionHistoryResponseModel>(await this.transactionHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTransactionHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.transactionHistoryRepository.Create(this.dalTransactionHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				var bo = this.bolTransactionHistoryMapper.MapModelToBO(transactionID, model);
				await this.transactionHistoryRepository.Update(this.dalTransactionHistoryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<ApiTransactionHistoryResponseModel>> GetProductID(int productID)
		{
			List<TransactionHistory> records = await this.transactionHistoryRepository.GetProductID(productID);

			return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
		}
		public async Task<List<ApiTransactionHistoryResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			List<TransactionHistory> records = await this.transactionHistoryRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);

			return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>43f3e294198d838ab31085cb71592aad</Hash>
</Codenesium>*/