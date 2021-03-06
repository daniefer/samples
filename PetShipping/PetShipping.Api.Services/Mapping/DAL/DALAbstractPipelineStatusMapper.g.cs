using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineStatusMapper
	{
		public virtual PipelineStatus MapBOToEF(
			BOPipelineStatus bo)
		{
			PipelineStatus efPipelineStatus = new PipelineStatus();
			efPipelineStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStatus;
		}

		public virtual BOPipelineStatus MapEFToBO(
			PipelineStatus ef)
		{
			var bo = new BOPipelineStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPipelineStatus> MapEFToBO(
			List<PipelineStatus> records)
		{
			List<BOPipelineStatus> response = new List<BOPipelineStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fd16f239ce9607c563b8a6e488e2617e</Hash>
</Codenesium>*/