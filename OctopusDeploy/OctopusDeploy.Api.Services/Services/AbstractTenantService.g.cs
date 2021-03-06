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
	public abstract class AbstractTenantService : AbstractService
	{
		private ITenantRepository tenantRepository;

		private IApiTenantRequestModelValidator tenantModelValidator;

		private IBOLTenantMapper bolTenantMapper;

		private IDALTenantMapper dalTenantMapper;

		private ILogger logger;

		public AbstractTenantService(
			ILogger logger,
			ITenantRepository tenantRepository,
			IApiTenantRequestModelValidator tenantModelValidator,
			IBOLTenantMapper bolTenantMapper,
			IDALTenantMapper dalTenantMapper)
			: base()
		{
			this.tenantRepository = tenantRepository;
			this.tenantModelValidator = tenantModelValidator;
			this.bolTenantMapper = bolTenantMapper;
			this.dalTenantMapper = dalTenantMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTenantResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.tenantRepository.All(limit, offset);

			return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTenantResponseModel> Get(string id)
		{
			var record = await this.tenantRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model)
		{
			CreateResponse<ApiTenantResponseModel> response = new CreateResponse<ApiTenantResponseModel>(await this.tenantModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTenantMapper.MapModelToBO(default(string), model);
				var record = await this.tenantRepository.Create(this.dalTenantMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTenantResponseModel>> Update(
			string id,
			ApiTenantRequestModel model)
		{
			var validationResult = await this.tenantModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTenantMapper.MapModelToBO(id, model);
				await this.tenantRepository.Update(this.dalTenantMapper.MapBOToEF(bo));

				var record = await this.tenantRepository.Get(id);

				return new UpdateResponse<ApiTenantResponseModel>(this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTenantResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.tenantModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.tenantRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiTenantResponseModel> ByName(string name)
		{
			Tenant record = await this.tenantRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiTenantResponseModel>> ByDataVersion(byte[] dataVersion)
		{
			List<Tenant> records = await this.tenantRepository.ByDataVersion(dataVersion);

			return this.bolTenantMapper.MapBOToModel(this.dalTenantMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e38fb0e6e9f5e8105f19738afad3c2a3</Hash>
</Codenesium>*/