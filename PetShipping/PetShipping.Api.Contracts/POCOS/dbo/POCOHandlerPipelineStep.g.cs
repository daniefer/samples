using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOHandlerPipelineStep: AbstractPOCO
	{
		public POCOHandlerPipelineStep() : base()
		{}

		public POCOHandlerPipelineStep(
			int handlerId,
			int id,
			int pipelineStepId)
		{
			this.Id = id.ToInt();

			this.HandlerId = new ReferenceEntity<int>(handlerId,
			                                          nameof(ApiResponse.Handlers));
			this.PipelineStepId = new ReferenceEntity<int>(pipelineStepId,
			                                               nameof(ApiResponse.PipelineSteps));
		}

		public ReferenceEntity<int> HandlerId { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> PipelineStepId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeHandlerIdValue { get; set; } = true;

		public bool ShouldSerializeHandlerId()
		{
			return this.ShouldSerializeHandlerIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeHandlerIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>0852214b4c9f12a12971d3bfc30d435d</Hash>
</Codenesium>*/