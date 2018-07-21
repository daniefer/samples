using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class DALAbstractVoteTypesMapper
        {
                public virtual VoteTypes MapBOToEF(
                        BOVoteTypes bo)
                {
                        VoteTypes efVoteTypes = new VoteTypes();
                        efVoteTypes.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efVoteTypes;
                }

                public virtual BOVoteTypes MapEFToBO(
                        VoteTypes ef)
                {
                        var bo = new BOVoteTypes();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOVoteTypes> MapEFToBO(
                        List<VoteTypes> records)
                {
                        List<BOVoteTypes> response = new List<BOVoteTypes>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9fa4ab5c6ed5762cd4d8b345491cbbdd</Hash>
</Codenesium>*/