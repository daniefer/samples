using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IPhoneNumberTypeService
	{
		Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
			ApiPhoneNumberTypeRequestModel model);

		Task<UpdateResponse<ApiPhoneNumberTypeResponseModel>> Update(int phoneNumberTypeID,
		                                                              ApiPhoneNumberTypeRequestModel model);

		Task<ActionResponse> Delete(int phoneNumberTypeID);

		Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID);

		Task<List<ApiPhoneNumberTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>da55585df56bc29f9f91a7186965f7ba</Hash>
</Codenesium>*/