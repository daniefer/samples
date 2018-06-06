using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelIllustrationMapper
	{
		public virtual BOProductModelIllustration MapModelToBO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model
			)
		{
			BOProductModelIllustration boProductModelIllustration = new BOProductModelIllustration();

			boProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
			return boProductModelIllustration;
		}

		public virtual ApiProductModelIllustrationResponseModel MapBOToModel(
			BOProductModelIllustration boProductModelIllustration)
		{
			var model = new ApiProductModelIllustrationResponseModel();

			model.SetProperties(boProductModelIllustration.IllustrationID, boProductModelIllustration.ModifiedDate, boProductModelIllustration.ProductModelID);

			return model;
		}

		public virtual List<ApiProductModelIllustrationResponseModel> MapBOToModel(
			List<BOProductModelIllustration> items)
		{
			List<ApiProductModelIllustrationResponseModel> response = new List<ApiProductModelIllustrationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>348989f9678b5e8fc08dca04f72260bd</Hash>
</Codenesium>*/