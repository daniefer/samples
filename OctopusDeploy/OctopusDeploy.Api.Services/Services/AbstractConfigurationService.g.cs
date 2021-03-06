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
	public abstract class AbstractConfigurationService : AbstractService
	{
		private IConfigurationRepository configurationRepository;

		private IApiConfigurationRequestModelValidator configurationModelValidator;

		private IBOLConfigurationMapper bolConfigurationMapper;

		private IDALConfigurationMapper dalConfigurationMapper;

		private ILogger logger;

		public AbstractConfigurationService(
			ILogger logger,
			IConfigurationRepository configurationRepository,
			IApiConfigurationRequestModelValidator configurationModelValidator,
			IBOLConfigurationMapper bolConfigurationMapper,
			IDALConfigurationMapper dalConfigurationMapper)
			: base()
		{
			this.configurationRepository = configurationRepository;
			this.configurationModelValidator = configurationModelValidator;
			this.bolConfigurationMapper = bolConfigurationMapper;
			this.dalConfigurationMapper = dalConfigurationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiConfigurationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.configurationRepository.All(limit, offset);

			return this.bolConfigurationMapper.MapBOToModel(this.dalConfigurationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiConfigurationResponseModel> Get(string id)
		{
			var record = await this.configurationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolConfigurationMapper.MapBOToModel(this.dalConfigurationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiConfigurationResponseModel>> Create(
			ApiConfigurationRequestModel model)
		{
			CreateResponse<ApiConfigurationResponseModel> response = new CreateResponse<ApiConfigurationResponseModel>(await this.configurationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolConfigurationMapper.MapModelToBO(default(string), model);
				var record = await this.configurationRepository.Create(this.dalConfigurationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolConfigurationMapper.MapBOToModel(this.dalConfigurationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiConfigurationResponseModel>> Update(
			string id,
			ApiConfigurationRequestModel model)
		{
			var validationResult = await this.configurationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolConfigurationMapper.MapModelToBO(id, model);
				await this.configurationRepository.Update(this.dalConfigurationMapper.MapBOToEF(bo));

				var record = await this.configurationRepository.Get(id);

				return new UpdateResponse<ApiConfigurationResponseModel>(this.bolConfigurationMapper.MapBOToModel(this.dalConfigurationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiConfigurationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.configurationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.configurationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ed0b0ef247a2049520f77297c94bea4</Hash>
</Codenesium>*/