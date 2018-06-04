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
	public abstract class AbstractTransactionHistoryArchiveService: AbstractService
	{
		private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;
		private IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator;
		private IBOLTransactionHistoryArchiveMapper BOLTransactionHistoryArchiveMapper;
		private IDALTransactionHistoryArchiveMapper DALTransactionHistoryArchiveMapper;
		private ILogger logger;

		public AbstractTransactionHistoryArchiveService(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper boltransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper daltransactionHistoryArchiveMapper)
			: base()

		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.BOLTransactionHistoryArchiveMapper = boltransactionHistoryArchiveMapper;
			this.DALTransactionHistoryArchiveMapper = daltransactionHistoryArchiveMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.transactionHistoryArchiveRepository.All(skip, take, orderClause);

			return this.BOLTransactionHistoryArchiveMapper.MapBOToModel(this.DALTransactionHistoryArchiveMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID)
		{
			var record = await transactionHistoryArchiveRepository.Get(transactionID);

			return this.BOLTransactionHistoryArchiveMapper.MapBOToModel(this.DALTransactionHistoryArchiveMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
			ApiTransactionHistoryArchiveRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveResponseModel> response = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLTransactionHistoryArchiveMapper.MapModelToBO(default (int), model);
				var record = await this.transactionHistoryArchiveRepository.Create(this.DALTransactionHistoryArchiveMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLTransactionHistoryArchiveMapper.MapBOToModel(this.DALTransactionHistoryArchiveMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				var bo = this.BOLTransactionHistoryArchiveMapper.MapModelToBO(transactionID, model);
				await this.transactionHistoryArchiveRepository.Update(this.DALTransactionHistoryArchiveMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryArchiveRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetProductID(int productID)
		{
			List<TransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.GetProductID(productID);

			return this.BOLTransactionHistoryArchiveMapper.MapBOToModel(this.DALTransactionHistoryArchiveMapper.MapEFToBO(records));
		}
		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			List<TransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);

			return this.BOLTransactionHistoryArchiveMapper.MapBOToModel(this.DALTransactionHistoryArchiveMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>316e174972ed1ab4aab1251288088fca</Hash>
</Codenesium>*/