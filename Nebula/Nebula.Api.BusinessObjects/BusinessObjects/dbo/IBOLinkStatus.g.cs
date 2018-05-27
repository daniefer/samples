using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkStatus
	{
		Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
			ApiLinkStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkStatusResponseModel> Get(int id);

		Task<List<ApiLinkStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiLinkStatusResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>7e60bd5ae3e8313faeaedd24532d4370</Hash>
</Codenesium>*/