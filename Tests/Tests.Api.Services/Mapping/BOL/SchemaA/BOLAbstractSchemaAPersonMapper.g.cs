using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractSchemaAPersonMapper
	{
		public virtual BOSchemaAPerson MapModelToBO(
			int id,
			ApiSchemaAPersonRequestModel model
			)
		{
			BOSchemaAPerson boSchemaAPerson = new BOSchemaAPerson();
			boSchemaAPerson.SetProperties(
				id,
				model.Name);
			return boSchemaAPerson;
		}

		public virtual ApiSchemaAPersonResponseModel MapBOToModel(
			BOSchemaAPerson boSchemaAPerson)
		{
			var model = new ApiSchemaAPersonResponseModel();

			model.SetProperties(boSchemaAPerson.Id, boSchemaAPerson.Name);

			return model;
		}

		public virtual List<ApiSchemaAPersonResponseModel> MapBOToModel(
			List<BOSchemaAPerson> items)
		{
			List<ApiSchemaAPersonResponseModel> response = new List<ApiSchemaAPersonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5991288589c4985c1ebbd3edcc9cb646</Hash>
</Codenesium>*/