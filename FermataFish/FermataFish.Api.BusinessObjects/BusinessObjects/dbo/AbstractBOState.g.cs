using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOState
	{
		private IStateRepository stateRepository;
		private IStateModelValidator stateModelValidator;
		private ILogger logger;

		public AbstractBOState(
			ILogger logger,
			IStateRepository stateRepository,
			IStateModelValidator stateModelValidator)

		{
			this.stateRepository = stateRepository;
			this.stateModelValidator = stateModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateRepository.All(skip, take, orderClause);
		}

		public virtual POCOState Get(int id)
		{
			return this.stateRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOState>> Create(
			StateModel model)
		{
			CreateResponse<POCOState> response = new CreateResponse<POCOState>(await this.stateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOState record = this.stateRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			StateModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.stateRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.stateRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1731d042bf58b5a677ebeb3c30619aba</Hash>
</Codenesium>*/