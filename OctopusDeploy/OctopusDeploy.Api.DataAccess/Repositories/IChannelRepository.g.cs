using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IChannelRepository
        {
                Task<Channel> Create(Channel item);

                Task Update(Channel item);

                Task Delete(string id);

                Task<Channel> Get(string id);

                Task<List<Channel>> All(int limit = int.MaxValue, int offset = 0);

                Task<Channel> GetNameProjectId(string name, string projectId);

                Task<List<Channel>> GetDataVersion(byte[] dataVersion);

                Task<List<Channel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>03bb3ba1c39159f185cbef5920a94241</Hash>
</Codenesium>*/