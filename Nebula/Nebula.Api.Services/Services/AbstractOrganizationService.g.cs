using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractOrganizationService : AbstractService
	{
		private IOrganizationRepository organizationRepository;

		private IApiOrganizationRequestModelValidator organizationModelValidator;

		private IBOLOrganizationMapper bolOrganizationMapper;

		private IDALOrganizationMapper dalOrganizationMapper;

		private IBOLTeamMapper bolTeamMapper;

		private IDALTeamMapper dalTeamMapper;

		private ILogger logger;

		public AbstractOrganizationService(
			ILogger logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper bolOrganizationMapper,
			IDALOrganizationMapper dalOrganizationMapper,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper)
			: base()
		{
			this.organizationRepository = organizationRepository;
			this.organizationModelValidator = organizationModelValidator;
			this.bolOrganizationMapper = bolOrganizationMapper;
			this.dalOrganizationMapper = dalOrganizationMapper;
			this.bolTeamMapper = bolTeamMapper;
			this.dalTeamMapper = dalTeamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.organizationRepository.All(limit, offset);

			return this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOrganizationResponseModel> Get(int id)
		{
			var record = await this.organizationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model)
		{
			CreateResponse<ApiOrganizationResponseModel> response = new CreateResponse<ApiOrganizationResponseModel>(await this.organizationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolOrganizationMapper.MapModelToBO(default(int), model);
				var record = await this.organizationRepository.Create(this.dalOrganizationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOrganizationResponseModel>> Update(
			int id,
			ApiOrganizationRequestModel model)
		{
			var validationResult = await this.organizationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolOrganizationMapper.MapModelToBO(id, model);
				await this.organizationRepository.Update(this.dalOrganizationMapper.MapBOToEF(bo));

				var record = await this.organizationRepository.Get(id);

				return new UpdateResponse<ApiOrganizationResponseModel>(this.bolOrganizationMapper.MapBOToModel(this.dalOrganizationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiOrganizationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.organizationRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTeamResponseModel>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Team> records = await this.organizationRepository.Teams(organizationId, limit, offset);

			return this.bolTeamMapper.MapBOToModel(this.dalTeamMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c750793f753954f010191417600541ab</Hash>
</Codenesium>*/