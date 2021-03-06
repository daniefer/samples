using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractLinkTypesMapper
	{
		public virtual BOLinkTypes MapModelToBO(
			int id,
			ApiLinkTypesRequestModel model
			)
		{
			BOLinkTypes boLinkTypes = new BOLinkTypes();
			boLinkTypes.SetProperties(
				id,
				model.Type);
			return boLinkTypes;
		}

		public virtual ApiLinkTypesResponseModel MapBOToModel(
			BOLinkTypes boLinkTypes)
		{
			var model = new ApiLinkTypesResponseModel();

			model.SetProperties(boLinkTypes.Id, boLinkTypes.Type);

			return model;
		}

		public virtual List<ApiLinkTypesResponseModel> MapBOToModel(
			List<BOLinkTypes> items)
		{
			List<ApiLinkTypesResponseModel> response = new List<ApiLinkTypesResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a5ce6ecbe047a389466782d6a5a2e0b</Hash>
</Codenesium>*/