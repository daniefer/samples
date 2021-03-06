using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("AirTransport", Schema="dbo")]
	public partial class AirTransport : AbstractEntity
	{
		public AirTransport()
		{
		}

		public virtual void SetProperties(
			int airlineId,
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.AirlineId = airlineId;
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId;
			this.Id = id;
			this.LandDate = landDate;
			this.PipelineStepId = pipelineStepId;
			this.TakeoffDate = takeoffDate;
		}

		[Key]
		[Column("airlineId")]
		public int AirlineId { get; private set; }

		[Column("flightNumber")]
		public string FlightNumber { get; private set; }

		[Column("handlerId")]
		public int HandlerId { get; private set; }

		[Column("id")]
		public int Id { get; private set; }

		[Column("landDate")]
		public DateTime LandDate { get; private set; }

		[Column("pipelineStepId")]
		public int PipelineStepId { get; private set; }

		[Column("takeoffDate")]
		public DateTime TakeoffDate { get; private set; }

		[ForeignKey("HandlerId")]
		public virtual Handler HandlerNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>66185f2b3ada635d48bcd48269c26a36</Hash>
</Codenesium>*/