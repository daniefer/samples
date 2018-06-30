using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentEnvironmentRepository
        {
                Task<DeploymentEnvironment> Create(DeploymentEnvironment item);

                Task Update(DeploymentEnvironment item);

                Task Delete(string id);

                Task<DeploymentEnvironment> Get(string id);

                Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset = 0);

                Task<DeploymentEnvironment> ByName(string name);

                Task<List<DeploymentEnvironment>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>a2052fe69a831d88ab08cb20378d4378</Hash>
</Codenesium>*/