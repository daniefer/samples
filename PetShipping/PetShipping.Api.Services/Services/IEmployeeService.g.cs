using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model);

		Task<UpdateResponse<ApiEmployeeResponseModel>> Update(int id,
		                                                       ApiEmployeeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEmployeeResponseModel> Get(int id);

		Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0669c2b7f0708da328ae3624761e23de</Hash>
</Codenesium>*/