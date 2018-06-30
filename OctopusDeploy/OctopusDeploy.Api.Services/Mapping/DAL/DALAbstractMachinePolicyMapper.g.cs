using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractMachinePolicyMapper
        {
                public virtual MachinePolicy MapBOToEF(
                        BOMachinePolicy bo)
                {
                        MachinePolicy efMachinePolicy = new MachinePolicy();
                        efMachinePolicy.SetProperties(
                                bo.Id,
                                bo.IsDefault,
                                bo.JSON,
                                bo.Name);
                        return efMachinePolicy;
                }

                public virtual BOMachinePolicy MapEFToBO(
                        MachinePolicy ef)
                {
                        var bo = new BOMachinePolicy();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsDefault,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOMachinePolicy> MapEFToBO(
                        List<MachinePolicy> records)
                {
                        List<BOMachinePolicy> response = new List<BOMachinePolicy>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cb916757c8c3398d177c45c7b9fd662a</Hash>
</Codenesium>*/