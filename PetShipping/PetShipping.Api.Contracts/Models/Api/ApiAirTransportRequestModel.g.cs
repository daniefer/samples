using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiAirTransportRequestModel : AbstractApiRequestModel
        {
                public ApiAirTransportRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string flightNumber,
                        int handlerId,
                        int id,
                        DateTime landDate,
                        int pipelineStepId,
                        DateTime takeoffDate)
                {
                        this.FlightNumber = flightNumber;
                        this.HandlerId = handlerId;
                        this.Id = id;
                        this.LandDate = landDate;
                        this.PipelineStepId = pipelineStepId;
                        this.TakeoffDate = takeoffDate;
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
    <Hash>f875f5d9956101a4cb2ee54d34566637</Hash>
</Codenesium>*/