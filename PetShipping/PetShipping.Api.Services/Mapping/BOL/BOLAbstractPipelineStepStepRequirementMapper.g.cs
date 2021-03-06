using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStepRequirementMapper
	{
		public virtual BOPipelineStepStepRequirement MapModelToBO(
			int id,
			ApiPipelineStepStepRequirementRequestModel model
			)
		{
			BOPipelineStepStepRequirement boPipelineStepStepRequirement = new BOPipelineStepStepRequirement();
			boPipelineStepStepRequirement.SetProperties(
				id,
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
			return boPipelineStepStepRequirement;
		}

		public virtual ApiPipelineStepStepRequirementResponseModel MapBOToModel(
			BOPipelineStepStepRequirement boPipelineStepStepRequirement)
		{
			var model = new ApiPipelineStepStepRequirementResponseModel();

			model.SetProperties(boPipelineStepStepRequirement.Id, boPipelineStepStepRequirement.Details, boPipelineStepStepRequirement.PipelineStepId, boPipelineStepStepRequirement.RequirementMet);

			return model;
		}

		public virtual List<ApiPipelineStepStepRequirementResponseModel> MapBOToModel(
			List<BOPipelineStepStepRequirement> items)
		{
			List<ApiPipelineStepStepRequirementResponseModel> response = new List<ApiPipelineStepStepRequirementResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52dcb8eb068431e13af86a1f446f5c25</Hash>
</Codenesium>*/