using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class DALAbstractPostTypesMapper
        {
                public virtual PostTypes MapBOToEF(
                        BOPostTypes bo)
                {
                        PostTypes efPostTypes = new PostTypes();
                        efPostTypes.SetProperties(
                                bo.Id,
                                bo.Type);
                        return efPostTypes;
                }

                public virtual BOPostTypes MapEFToBO(
                        PostTypes ef)
                {
                        var bo = new BOPostTypes();

                        bo.SetProperties(
                                ef.Id,
                                ef.Type);
                        return bo;
                }

                public virtual List<BOPostTypes> MapEFToBO(
                        List<PostTypes> records)
                {
                        List<BOPostTypes> response = new List<BOPostTypes>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d239cc39d664420f4baf1afb56fbb28b</Hash>
</Codenesium>*/