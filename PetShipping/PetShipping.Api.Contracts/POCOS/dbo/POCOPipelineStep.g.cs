using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOPipelineStep: AbstractPOCO
	{
		public POCOPipelineStep() : base()
		{}

		public POCOPipelineStep(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id.ToInt();
			this.Name = name;

			this.PipelineStepStatusId = new ReferenceEntity<int>(pipelineStepStatusId,
			                                                     nameof(ApiResponse.PipelineStepStatus));
			this.ShipperId = new ReferenceEntity<int>(shipperId,
			                                          nameof(ApiResponse.Employees));
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> PipelineStepStatusId { get; set; }
		public ReferenceEntity<int> ShipperId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepStatusIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepStatusId()
		{
			return this.ShouldSerializePipelineStepStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipperIdValue { get; set; } = true;

		public bool ShouldSerializeShipperId()
		{
			return this.ShouldSerializeShipperIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializePipelineStepStatusIdValue = false;
			this.ShouldSerializeShipperIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a0512f710e6019d14e7c58f9c5892f23</Hash>
</Codenesium>*/