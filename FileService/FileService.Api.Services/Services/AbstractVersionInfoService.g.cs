using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractVersionInfoService : AbstractService
	{
		private IVersionInfoRepository versionInfoRepository;

		private IApiVersionInfoRequestModelValidator versionInfoModelValidator;

		private IBOLVersionInfoMapper bolVersionInfoMapper;

		private IDALVersionInfoMapper dalVersionInfoMapper;

		private ILogger logger;

		public AbstractVersionInfoService(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper bolVersionInfoMapper,
			IDALVersionInfoMapper dalVersionInfoMapper)
			: base()
		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.bolVersionInfoMapper = bolVersionInfoMapper;
			this.dalVersionInfoMapper = dalVersionInfoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.versionInfoRepository.All(limit, offset);

			return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
		{
			var record = await this.versionInfoRepository.Get(version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolVersionInfoMapper.MapModelToBO(default(long), model);
				var record = await this.versionInfoRepository.Create(this.dalVersionInfoMapper.MapBOToEF(bo));

				response.SetRecord(this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVersionInfoResponseModel>> Update(
			long version,
			ApiVersionInfoRequestModel model)
		{
			var validationResult = await this.versionInfoModelValidator.ValidateUpdateAsync(version, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolVersionInfoMapper.MapModelToBO(version, model);
				await this.versionInfoRepository.Update(this.dalVersionInfoMapper.MapBOToEF(bo));

				var record = await this.versionInfoRepository.Get(version);

				return new UpdateResponse<ApiVersionInfoResponseModel>(this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVersionInfoResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			long version)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateDeleteAsync(version));
			if (response.Success)
			{
				await this.versionInfoRepository.Delete(version);
			}

			return response;
		}

		public async Task<ApiVersionInfoResponseModel> ByVersion(long version)
		{
			VersionInfo record = await this.versionInfoRepository.ByVersion(version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>8de93466d04eed051fc5bd5127408570</Hash>
</Codenesium>*/