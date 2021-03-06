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
	public abstract class AbstractBusinessEntityContactService : AbstractService
	{
		private IBusinessEntityContactRepository businessEntityContactRepository;

		private IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator;

		private IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper;

		private IDALBusinessEntityContactMapper dalBusinessEntityContactMapper;

		private ILogger logger;

		public AbstractBusinessEntityContactService(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper)
			: base()
		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.bolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.dalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.businessEntityContactRepository.All(limit, offset);

			return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID)
		{
			var record = await this.businessEntityContactRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model)
		{
			CreateResponse<ApiBusinessEntityContactResponseModel> response = new CreateResponse<ApiBusinessEntityContactResponseModel>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolBusinessEntityContactMapper.MapModelToBO(default(int), model);
				var record = await this.businessEntityContactRepository.Create(this.dalBusinessEntityContactMapper.MapBOToEF(bo));

				response.SetRecord(this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityContactResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model)
		{
			var validationResult = await this.businessEntityContactModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolBusinessEntityContactMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityContactRepository.Update(this.dalBusinessEntityContactMapper.MapBOToEF(bo));

				var record = await this.businessEntityContactRepository.Get(businessEntityID);

				return new UpdateResponse<ApiBusinessEntityContactResponseModel>(this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBusinessEntityContactResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.businessEntityContactRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID)
		{
			List<BusinessEntityContact> records = await this.businessEntityContactRepository.ByContactTypeID(contactTypeID);

			return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public async Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID)
		{
			List<BusinessEntityContact> records = await this.businessEntityContactRepository.ByPersonID(personID);

			return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1946c017c6090a03063221151db95524</Hash>
</Codenesium>*/