using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IUserRoleRepository
        {
                Task<UserRole> Create(UserRole item);

                Task Update(UserRole item);

                Task Delete(string id);

                Task<UserRole> Get(string id);

                Task<List<UserRole>> All(int limit = int.MaxValue, int offset = 0);

                Task<UserRole> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>c689210e8e754ab1ccb9d007698bf081</Hash>
</Codenesium>*/