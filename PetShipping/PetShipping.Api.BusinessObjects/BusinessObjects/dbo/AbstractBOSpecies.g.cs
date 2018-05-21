using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOSpecies: AbstractBOManager
	{
		private ISpeciesRepository speciesRepository;
		private IApiSpeciesModelValidator speciesModelValidator;
		private ILogger logger;

		public AbstractBOSpecies(
			ILogger logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesModelValidator speciesModelValidator)
			: base()

		{
			this.speciesRepository = speciesRepository;
			this.speciesModelValidator = speciesModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSpecies> Get(int id)
		{
			return this.speciesRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSpecies>> Create(
			ApiSpeciesModel model)
		{
			CreateResponse<POCOSpecies> response = new CreateResponse<POCOSpecies>(await this.speciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpecies record = await this.speciesRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpeciesModel model)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.speciesRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.speciesRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2553c7d8c153b41e1d0bbfd07530834c</Hash>
</Codenesium>*/