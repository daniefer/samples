using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductModelProductDescriptionCultureRequestModelValidator: AbstractApiProductModelProductDescriptionCultureRequestModelValidator, IApiProductModelProductDescriptionCultureRequestModelValidator
        {
                public ApiProductModelProductDescriptionCultureRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        this.CultureIDRules();
                        this.ModifiedDateRules();
                        this.ProductDescriptionIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        this.CultureIDRules();
                        this.ModifiedDateRules();
                        this.ProductDescriptionIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0deb677657da1aeeaa8891dcf9c29509</Hash>
</Codenesium>*/