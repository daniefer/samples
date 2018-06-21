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
        public abstract class AbstractDeploymentEnvironmentService : AbstractService
        {
                private IDeploymentEnvironmentRepository deploymentEnvironmentRepository;

                private IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator;

                private IBOLDeploymentEnvironmentMapper bolDeploymentEnvironmentMapper;

                private IDALDeploymentEnvironmentMapper dalDeploymentEnvironmentMapper;

                private ILogger logger;

                public AbstractDeploymentEnvironmentService(
                        ILogger logger,
                        IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
                        IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
                        IBOLDeploymentEnvironmentMapper bolDeploymentEnvironmentMapper,
                        IDALDeploymentEnvironmentMapper dalDeploymentEnvironmentMapper)
                        : base()
                {
                        this.deploymentEnvironmentRepository = deploymentEnvironmentRepository;
                        this.deploymentEnvironmentModelValidator = deploymentEnvironmentModelValidator;
                        this.bolDeploymentEnvironmentMapper = bolDeploymentEnvironmentMapper;
                        this.dalDeploymentEnvironmentMapper = dalDeploymentEnvironmentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.deploymentEnvironmentRepository.All(limit, offset);

                        return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentEnvironmentResponseModel> Get(string id)
                {
                        var record = await this.deploymentEnvironmentRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> Create(
                        ApiDeploymentEnvironmentRequestModel model)
                {
                        CreateResponse<ApiDeploymentEnvironmentResponseModel> response = new CreateResponse<ApiDeploymentEnvironmentResponseModel>(await this.deploymentEnvironmentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentEnvironmentMapper.MapModelToBO(default(string), model);
                                var record = await this.deploymentEnvironmentRepository.Create(this.dalDeploymentEnvironmentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiDeploymentEnvironmentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentEnvironmentModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentEnvironmentMapper.MapModelToBO(id, model);
                                await this.deploymentEnvironmentRepository.Update(this.dalDeploymentEnvironmentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentEnvironmentModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.deploymentEnvironmentRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiDeploymentEnvironmentResponseModel> GetName(string name)
                {
                        DeploymentEnvironment record = await this.deploymentEnvironmentRepository.GetName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiDeploymentEnvironmentResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<DeploymentEnvironment> records = await this.deploymentEnvironmentRepository.GetDataVersion(dataVersion);

                        return this.bolDeploymentEnvironmentMapper.MapBOToModel(this.dalDeploymentEnvironmentMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>002ce2cff3850ab547b96ed3cc39b06f</Hash>
</Codenesium>*/