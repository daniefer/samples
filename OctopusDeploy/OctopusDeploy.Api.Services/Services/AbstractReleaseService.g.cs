using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractReleaseService : AbstractService
        {
                private IReleaseRepository releaseRepository;

                private IApiReleaseRequestModelValidator releaseModelValidator;

                private IBOLReleaseMapper bolReleaseMapper;

                private IDALReleaseMapper dalReleaseMapper;

                private ILogger logger;

                public AbstractReleaseService(
                        ILogger logger,
                        IReleaseRepository releaseRepository,
                        IApiReleaseRequestModelValidator releaseModelValidator,
                        IBOLReleaseMapper bolReleaseMapper,
                        IDALReleaseMapper dalReleaseMapper)
                        : base()
                {
                        this.releaseRepository = releaseRepository;
                        this.releaseModelValidator = releaseModelValidator;
                        this.bolReleaseMapper = bolReleaseMapper;
                        this.dalReleaseMapper = dalReleaseMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiReleaseResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.releaseRepository.All(limit, offset);

                        return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiReleaseResponseModel> Get(string id)
                {
                        var record = await this.releaseRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiReleaseResponseModel>> Create(
                        ApiReleaseRequestModel model)
                {
                        CreateResponse<ApiReleaseResponseModel> response = new CreateResponse<ApiReleaseResponseModel>(await this.releaseModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolReleaseMapper.MapModelToBO(default(string), model);
                                var record = await this.releaseRepository.Create(this.dalReleaseMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiReleaseRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.releaseModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolReleaseMapper.MapModelToBO(id, model);
                                await this.releaseRepository.Update(this.dalReleaseMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.releaseModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.releaseRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiReleaseResponseModel> GetVersionProjectId(string version, string projectId)
                {
                        Release record = await this.releaseRepository.GetVersionProjectId(version, projectId);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiReleaseResponseModel>> GetIdAssembled(string id, DateTimeOffset assembled)
                {
                        List<Release> records = await this.releaseRepository.GetIdAssembled(id, assembled);

                        return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(records));
                }

                public async Task<List<ApiReleaseResponseModel>> GetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
                {
                        List<Release> records = await this.releaseRepository.GetProjectDeploymentProcessSnapshotId(projectDeploymentProcessSnapshotId);

                        return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(records));
                }

                public async Task<List<ApiReleaseResponseModel>> GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
                {
                        List<Release> records = await this.releaseRepository.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(id, version, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, channelId, assembled);

                        return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(records));
                }

                public async Task<List<ApiReleaseResponseModel>> GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
                {
                        List<Release> records = await this.releaseRepository.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(id, channelId, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, version, assembled);

                        return this.bolReleaseMapper.MapBOToModel(this.dalReleaseMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b2d39a7719eeb6b569a117c8035d2343</Hash>
</Codenesium>*/