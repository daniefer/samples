using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiDeploymentProcessRequestModelValidator : AbstractValidator<ApiDeploymentProcessRequestModel>
        {
                private string existingRecordId;

                private IDeploymentProcessRepository deploymentProcessRepository;

                public AbstractApiDeploymentProcessRequestModelValidator(IDeploymentProcessRepository deploymentProcessRepository)
                {
                        this.deploymentProcessRepository = deploymentProcessRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentProcessRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsFrozenRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void OwnerIdRules()
                {
                        this.RuleFor(x => x.OwnerId).NotNull();
                        this.RuleFor(x => x.OwnerId).Length(0, 150);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                }

                public virtual void VersionRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>daf178fbe0bd34b29851e5df2373cedd</Hash>
</Codenesium>*/