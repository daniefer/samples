using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("OtherTransport", Schema="dbo")]
	public partial class OtherTransport : AbstractEntity
	{
		public OtherTransport()
		{
		}

		public virtual void SetProperties(
			int handlerId,
			int id,
			int pipelineStepId)
		{
			this.HandlerId = handlerId;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
		}

		[Column("handlerId")]
		public int HandlerId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("pipelineStepId")]
		public int PipelineStepId { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler HandlerNavigation { get; private set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStepNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bfba0768fd6a41a6e41b5d13b3e9d759</Hash>
</Codenesium>*/