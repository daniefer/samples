using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IReleaseRepository
        {
                Task<Release> Create(Release item);

                Task Update(Release item);

                Task Delete(string id);

                Task<Release> Get(string id);

                Task<List<Release>> All(int limit = int.MaxValue, int offset = 0);

                Task<Release> ByVersionProjectId(string version, string projectId);

                Task<List<Release>> ByIdAssembled(string id, DateTimeOffset assembled);

                Task<List<Release>> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId);

                Task<List<Release>> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled);

                Task<List<Release>> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled);
        }
}

/*<Codenesium>
    <Hash>9b4523f98cf1feb3f2da7b767754bba7</Hash>
</Codenesium>*/