using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		Task<PipelineStepStepRequirement> Create(PipelineStepStepRequirement item);

		Task Update(PipelineStepStepRequirement item);

		Task Delete(int id);

		Task<PipelineStepStepRequirement> Get(int id);

		Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset = 0);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>ddbe4245c171c9687daebdc9e27b726e</Hash>
</Codenesium>*/