using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOAWBuildVersion: AbstractBOManager
	{
		private IAWBuildVersionRepository aWBuildVersionRepository;
		private IApiAWBuildVersionModelValidator aWBuildVersionModelValidator;
		private ILogger logger;

		public AbstractBOAWBuildVersion(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionModelValidator aWBuildVersionModelValidator)
			: base()

		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.aWBuildVersionRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOAWBuildVersion> Get(int systemInformationID)
		{
			return this.aWBuildVersionRepository.Get(systemInformationID);
		}

		public virtual async Task<CreateResponse<POCOAWBuildVersion>> Create(
			ApiAWBuildVersionModel model)
		{
			CreateResponse<POCOAWBuildVersion> response = new CreateResponse<POCOAWBuildVersion>(await this.aWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAWBuildVersion record = await this.aWBuildVersionRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int systemInformationID,
			ApiAWBuildVersionModel model)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model));

			if (response.Success)
			{
				await this.aWBuildVersionRepository.Update(systemInformationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));

			if (response.Success)
			{
				await this.aWBuildVersionRepository.Delete(systemInformationID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>244841cdbbfe57a9dbe1b2dc8c0a7cb3</Hash>
</Codenesium>*/