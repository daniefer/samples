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
        public abstract class AbstractApiCertificateRequestModelValidator : AbstractValidator<ApiCertificateRequestModel>
        {
                private string existingRecordId;

                private ICertificateRepository certificateRepository;

                public AbstractApiCertificateRequestModelValidator(ICertificateRepository certificateRepository)
                {
                        this.certificateRepository = certificateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCertificateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ArchivedRules()
                {
                }

                public virtual void CreatedRules()
                {
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void EnvironmentIdsRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void NotAfterRules()
                {
                }

                public virtual void SubjectRules()
                {
                        this.RuleFor(x => x.Subject).NotNull();
                }

                public virtual void TenantIdsRules()
                {
                }

                public virtual void TenantTagsRules()
                {
                }

                public virtual void ThumbprintRules()
                {
                        this.RuleFor(x => x.Thumbprint).NotNull();
                        this.RuleFor(x => x.Thumbprint).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>1455f0e82643ac769a4517f718434230</Hash>
</Codenesium>*/