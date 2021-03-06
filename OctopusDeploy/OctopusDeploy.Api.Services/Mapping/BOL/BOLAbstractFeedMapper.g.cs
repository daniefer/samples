using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractFeedMapper
	{
		public virtual BOFeed MapModelToBO(
			string id,
			ApiFeedRequestModel model
			)
		{
			BOFeed boFeed = new BOFeed();
			boFeed.SetProperties(
				id,
				model.FeedType,
				model.FeedUri,
				model.JSON,
				model.Name);
			return boFeed;
		}

		public virtual ApiFeedResponseModel MapBOToModel(
			BOFeed boFeed)
		{
			var model = new ApiFeedResponseModel();

			model.SetProperties(boFeed.Id, boFeed.FeedType, boFeed.FeedUri, boFeed.JSON, boFeed.Name);

			return model;
		}

		public virtual List<ApiFeedResponseModel> MapBOToModel(
			List<BOFeed> items)
		{
			List<ApiFeedResponseModel> response = new List<ApiFeedResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>702884ac2a33d07662508c9cb4ce754d</Hash>
</Codenesium>*/