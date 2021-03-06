using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractWorkerPoolMapper
	{
		public virtual WorkerPool MapBOToEF(
			BOWorkerPool bo)
		{
			WorkerPool efWorkerPool = new WorkerPool();
			efWorkerPool.SetProperties(
				bo.Id,
				bo.IsDefault,
				bo.JSON,
				bo.Name,
				bo.SortOrder);
			return efWorkerPool;
		}

		public virtual BOWorkerPool MapEFToBO(
			WorkerPool ef)
		{
			var bo = new BOWorkerPool();

			bo.SetProperties(
				ef.Id,
				ef.IsDefault,
				ef.JSON,
				ef.Name,
				ef.SortOrder);
			return bo;
		}

		public virtual List<BOWorkerPool> MapEFToBO(
			List<WorkerPool> records)
		{
			List<BOWorkerPool> response = new List<BOWorkerPool>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>11976b119b4cb21837947f15dd2a21ef</Hash>
</Codenesium>*/