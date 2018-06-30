using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ICertificateRepository
        {
                Task<Certificate> Create(Certificate item);

                Task Update(Certificate item);

                Task Delete(string id);

                Task<Certificate> Get(string id);

                Task<List<Certificate>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Certificate>> ByCreated(DateTimeOffset created);

                Task<List<Certificate>> ByDataVersion(byte[] dataVersion);

                Task<List<Certificate>> ByNotAfter(DateTimeOffset notAfter);

                Task<List<Certificate>> ByThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>f3f2976cb88c66bf6b75fb35bb96ed07</Hash>
</Codenesium>*/