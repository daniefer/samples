using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public interface IFileService
	{
		Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model);

		Task<UpdateResponse<ApiFileResponseModel>> Update(int id,
		                                                   ApiFileRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileResponseModel> Get(int id);

		Task<List<ApiFileResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>504f053159f41afaf2b1957650916b58</Hash>
</Codenesium>*/