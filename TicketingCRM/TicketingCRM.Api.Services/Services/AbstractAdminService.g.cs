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
	public abstract class AbstractAdminService : AbstractService
	{
		private IAdminRepository adminRepository;

		private IApiAdminRequestModelValidator adminModelValidator;

		private IBOLAdminMapper bolAdminMapper;

		private IDALAdminMapper dalAdminMapper;

		private IBOLVenueMapper bolVenueMapper;

		private IDALVenueMapper dalVenueMapper;

		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.adminRepository = adminRepository;
			this.adminModelValidator = adminModelValidator;
			this.bolAdminMapper = bolAdminMapper;
			this.dalAdminMapper = dalAdminMapper;
			this.bolVenueMapper = bolVenueMapper;
			this.dalVenueMapper = dalVenueMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAdminResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.adminRepository.All(limit, offset);

			return this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAdminResponseModel> Get(int id)
		{
			var record = await this.adminRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model)
		{
			CreateResponse<ApiAdminResponseModel> response = new CreateResponse<ApiAdminResponseModel>(await this.adminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolAdminMapper.MapModelToBO(default(int), model);
				var record = await this.adminRepository.Create(this.dalAdminMapper.MapBOToEF(bo));

				response.SetRecord(this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAdminResponseModel>> Update(
			int id,
			ApiAdminRequestModel model)
		{
			var validationResult = await this.adminModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolAdminMapper.MapModelToBO(id, model);
				await this.adminRepository.Update(this.dalAdminMapper.MapBOToEF(bo));

				var record = await this.adminRepository.Get(id);

				return new UpdateResponse<ApiAdminResponseModel>(this.bolAdminMapper.MapBOToModel(this.dalAdminMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAdminResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.adminRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiVenueResponseModel>> Venues(int adminId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.adminRepository.Venues(adminId, limit, offset);

			return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ea6a1370612da1170db94b0430c952c9</Hash>
</Codenesium>*/