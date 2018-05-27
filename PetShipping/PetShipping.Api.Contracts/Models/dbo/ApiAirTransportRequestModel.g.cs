using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiAirTransportRequestModel: AbstractApiRequestModel
	{
		public ApiAirTransportRequestModel() : base()
		{}

		public void SetProperties(
			string flightNumber,
			int handlerId,
			int id,
			DateTime landDate,
			int pipelineStepId,
			DateTime takeoffDate)
		{
			this.FlightNumber = flightNumber;
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.LandDate = landDate.ToDateTime();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.TakeoffDate = takeoffDate.ToDateTime();
		}

		private string flightNumber;

		[Required]
		public string FlightNumber
		{
			get
			{
				return this.flightNumber;
			}

			set
			{
				this.flightNumber = value;
			}
		}

		private int handlerId;

		[Required]
		public int HandlerId
		{
			get
			{
				return this.handlerId;
			}

			set
			{
				this.handlerId = value;
			}
		}

		private int id;

		[Required]
		public int Id
		{
			get
			{
				return this.id;
			}

			set
			{
				this.id = value;
			}
		}

		private DateTime landDate;

		[Required]
		public DateTime LandDate
		{
			get
			{
				return this.landDate;
			}

			set
			{
				this.landDate = value;
			}
		}

		private int pipelineStepId;

		[Required]
		public int PipelineStepId
		{
			get
			{
				return this.pipelineStepId;
			}

			set
			{
				this.pipelineStepId = value;
			}
		}

		private DateTime takeoffDate;

		[Required]
		public DateTime TakeoffDate
		{
			get
			{
				return this.takeoffDate;
			}

			set
			{
				this.takeoffDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e6ef093ffabbfb9f6162c92aae03e6cc</Hash>
</Codenesium>*/