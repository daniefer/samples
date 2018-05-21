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
	public abstract class AbstractBOFamily: AbstractBOManager
	{
		private IFamilyRepository familyRepository;
		private IApiFamilyModelValidator familyModelValidator;
		private ILogger logger;

		public AbstractBOFamily(
			ILogger logger,
			IFamilyRepository familyRepository,
			IApiFamilyModelValidator familyModelValidator)
			: base()

		{
			this.familyRepository = familyRepository;
			this.familyModelValidator = familyModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.familyRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOFamily> Get(int id)
		{
			return this.familyRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOFamily>> Create(
			ApiFamilyModel model)
		{
			CreateResponse<POCOFamily> response = new CreateResponse<POCOFamily>(await this.familyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOFamily record = await this.familyRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFamilyModel model)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.familyRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.familyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5d052386b3a87b15a2d4f413ed29a9c4</Hash>
</Codenesium>*/