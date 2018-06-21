using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStepStepRequirement : AbstractBusinessObject
        {
                public AbstractBOPipelineStepStepRequirement()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string details,
                                                  int pipelineStepId,
                                                  bool requirementMet)
                {
                        this.Details = details;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                        this.RequirementMet = requirementMet;
                }

                public string Details { get; private set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }

                public bool RequirementMet { get; private set; }
        }
}

/*<Codenesium>
    <Hash>38654048cc933f74c41589af98070bcc</Hash>
</Codenesium>*/