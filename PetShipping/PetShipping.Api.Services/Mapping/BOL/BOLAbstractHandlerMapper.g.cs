using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerMapper
	{
		public virtual BOHandler MapModelToBO(
			int id,
			ApiHandlerRequestModel model
			)
		{
			BOHandler boHandler = new BOHandler();

			boHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return boHandler;
		}

		public virtual ApiHandlerResponseModel MapBOToModel(
			BOHandler boHandler)
		{
			var model = new ApiHandlerResponseModel();

			model.SetProperties(boHandler.CountryId, boHandler.Email, boHandler.FirstName, boHandler.Id, boHandler.LastName, boHandler.Phone);

			return model;
		}

		public virtual List<ApiHandlerResponseModel> MapBOToModel(
			List<BOHandler> items)
		{
			List<ApiHandlerResponseModel> response = new List<ApiHandlerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>83775b4b53041400340681b9f4668304</Hash>
</Codenesium>*/