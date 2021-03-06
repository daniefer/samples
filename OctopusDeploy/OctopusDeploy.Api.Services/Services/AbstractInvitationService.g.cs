using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractInvitationService : AbstractService
	{
		private IInvitationRepository invitationRepository;

		private IApiInvitationRequestModelValidator invitationModelValidator;

		private IBOLInvitationMapper bolInvitationMapper;

		private IDALInvitationMapper dalInvitationMapper;

		private ILogger logger;

		public AbstractInvitationService(
			ILogger logger,
			IInvitationRepository invitationRepository,
			IApiInvitationRequestModelValidator invitationModelValidator,
			IBOLInvitationMapper bolInvitationMapper,
			IDALInvitationMapper dalInvitationMapper)
			: base()
		{
			this.invitationRepository = invitationRepository;
			this.invitationModelValidator = invitationModelValidator;
			this.bolInvitationMapper = bolInvitationMapper;
			this.dalInvitationMapper = dalInvitationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiInvitationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.invitationRepository.All(limit, offset);

			return this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiInvitationResponseModel> Get(string id)
		{
			var record = await this.invitationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiInvitationResponseModel>> Create(
			ApiInvitationRequestModel model)
		{
			CreateResponse<ApiInvitationResponseModel> response = new CreateResponse<ApiInvitationResponseModel>(await this.invitationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolInvitationMapper.MapModelToBO(default(string), model);
				var record = await this.invitationRepository.Create(this.dalInvitationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiInvitationResponseModel>> Update(
			string id,
			ApiInvitationRequestModel model)
		{
			var validationResult = await this.invitationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolInvitationMapper.MapModelToBO(id, model);
				await this.invitationRepository.Update(this.dalInvitationMapper.MapBOToEF(bo));

				var record = await this.invitationRepository.Get(id);

				return new UpdateResponse<ApiInvitationResponseModel>(this.bolInvitationMapper.MapBOToModel(this.dalInvitationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiInvitationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.invitationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.invitationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a8e2bb8381a30e942e041be68adb5da3</Hash>
</Codenesium>*/