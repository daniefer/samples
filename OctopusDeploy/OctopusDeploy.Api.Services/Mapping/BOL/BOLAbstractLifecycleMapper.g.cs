using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractLifecycleMapper
	{
		public virtual BOLifecycle MapModelToBO(
			string id,
			ApiLifecycleRequestModel model
			)
		{
			BOLifecycle boLifecycle = new BOLifecycle();
			boLifecycle.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.Name);
			return boLifecycle;
		}

		public virtual ApiLifecycleResponseModel MapBOToModel(
			BOLifecycle boLifecycle)
		{
			var model = new ApiLifecycleResponseModel();

			model.SetProperties(boLifecycle.Id, boLifecycle.DataVersion, boLifecycle.JSON, boLifecycle.Name);

			return model;
		}

		public virtual List<ApiLifecycleResponseModel> MapBOToModel(
			List<BOLifecycle> items)
		{
			List<ApiLifecycleResponseModel> response = new List<ApiLifecycleResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7bc30288b2918785b1c568d02dc0aa40</Hash>
</Codenesium>*/