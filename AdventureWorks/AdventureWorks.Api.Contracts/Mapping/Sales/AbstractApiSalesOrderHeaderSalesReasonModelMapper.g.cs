using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiSalesOrderHeaderSalesReasonModelMapper
	{
		public virtual ApiSalesOrderHeaderSalesReasonResponseModel MapRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel request)
		{
			var response = new ApiSalesOrderHeaderSalesReasonResponseModel();
			response.SetProperties(salesOrderID,
			                       request.ModifiedDate,
			                       request.SalesReasonID);
			return response;
		}

		public virtual ApiSalesOrderHeaderSalesReasonRequestModel MapResponseToRequest(
			ApiSalesOrderHeaderSalesReasonResponseModel response)
		{
			var request = new ApiSalesOrderHeaderSalesReasonRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.SalesReasonID);
			return request;
		}

		public JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> CreatePatch(ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.SalesReasonID, model.SalesReasonID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4deac86570df0b34c613f378b9abd376</Hash>
</Codenesium>*/