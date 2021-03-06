using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductSubcategoryMapper
	{
		public virtual BOProductSubcategory MapModelToBO(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model
			)
		{
			BOProductSubcategory boProductSubcategory = new BOProductSubcategory();
			boProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
			return boProductSubcategory;
		}

		public virtual ApiProductSubcategoryResponseModel MapBOToModel(
			BOProductSubcategory boProductSubcategory)
		{
			var model = new ApiProductSubcategoryResponseModel();

			model.SetProperties(boProductSubcategory.ProductSubcategoryID, boProductSubcategory.ModifiedDate, boProductSubcategory.Name, boProductSubcategory.ProductCategoryID, boProductSubcategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryResponseModel> MapBOToModel(
			List<BOProductSubcategory> items)
		{
			List<ApiProductSubcategoryResponseModel> response = new List<ApiProductSubcategoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7c8d141301718c5ff259cfa65fc6345b</Hash>
</Codenesium>*/