using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class ApiPenRequestModelValidator: AbstractApiPenRequestModelValidator, IApiPenRequestModelValidator
        {
                public ApiPenRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>c0d488fbd96393901ca775010668c03a</Hash>
</Codenesium>*/