using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface ITicketStatusService
	{
		Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
			ApiTicketStatusRequestModel model);

		Task<UpdateResponse<ApiTicketStatusResponseModel>> Update(int id,
		                                                           ApiTicketStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketStatusResponseModel> Get(int id);

		Task<List<ApiTicketStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b0ac5d9076cf8cf34359425a78fbccf0</Hash>
</Codenesium>*/