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
	public abstract class AbstractBOCountryRequirement
	{
		private ICountryRequirementRepository countryRequirementRepository;
		private ICountryRequirementModelValidator countryRequirementModelValidator;
		private ILogger logger;

		public AbstractBOCountryRequirement(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			ICountryRequirementModelValidator countryRequirementModelValidator)

		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRequirementRepository.All(skip, take, orderClause);
		}

		public virtual POCOCountryRequirement Get(int id)
		{
			return this.countryRequirementRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOCountryRequirement>> Create(
			CountryRequirementModel model)
		{
			CreateResponse<POCOCountryRequirement> response = new CreateResponse<POCOCountryRequirement>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountryRequirement record = this.countryRequirementRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			CountryRequirementModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.countryRequirementRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.countryRequirementRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>486a2bb95d8afc83d52fd1cfd8176167</Hash>
</Codenesium>*/