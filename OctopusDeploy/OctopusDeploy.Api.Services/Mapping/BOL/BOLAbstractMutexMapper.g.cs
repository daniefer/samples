using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractMutexMapper
	{
		public virtual BOMutex MapModelToBO(
			string id,
			ApiMutexRequestModel model
			)
		{
			BOMutex boMutex = new BOMutex();
			boMutex.SetProperties(
				id,
				model.JSON);
			return boMutex;
		}

		public virtual ApiMutexResponseModel MapBOToModel(
			BOMutex boMutex)
		{
			var model = new ApiMutexResponseModel();

			model.SetProperties(boMutex.Id, boMutex.JSON);

			return model;
		}

		public virtual List<ApiMutexResponseModel> MapBOToModel(
			List<BOMutex> items)
		{
			List<ApiMutexResponseModel> response = new List<ApiMutexResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>26224358a4493be70c290147a86ba969</Hash>
</Codenesium>*/