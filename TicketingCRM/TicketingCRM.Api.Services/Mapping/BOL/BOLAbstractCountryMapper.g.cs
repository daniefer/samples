using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractCountryMapper
	{
		public virtual BOCountry MapModelToBO(
			int id,
			ApiCountryRequestModel model
			)
		{
			BOCountry boCountry = new BOCountry();
			boCountry.SetProperties(
				id,
				model.Name);
			return boCountry;
		}

		public virtual ApiCountryResponseModel MapBOToModel(
			BOCountry boCountry)
		{
			var model = new ApiCountryResponseModel();

			model.SetProperties(boCountry.Id, boCountry.Name);

			return model;
		}

		public virtual List<ApiCountryResponseModel> MapBOToModel(
			List<BOCountry> items)
		{
			List<ApiCountryResponseModel> response = new List<ApiCountryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c24adb5fb479b86a2b6d2debfff15cc5</Hash>
</Codenesium>*/