using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLVersionInfoMapper
	{
		BOVersionInfo MapModelToBO(
			long version,
			ApiVersionInfoRequestModel model);

		ApiVersionInfoResponseModel MapBOToModel(
			BOVersionInfo boVersionInfo);

		List<ApiVersionInfoResponseModel> MapBOToModel(
			List<BOVersionInfo> items);
	}
}

/*<Codenesium>
    <Hash>635f005aa2572ffa6f135ea647583849</Hash>
</Codenesium>*/