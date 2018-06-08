using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonXTeacherRequestModelValidator: AbstractApiLessonXTeacherRequestModelValidator, IApiLessonXTeacherRequestModelValidator
        {
                public ApiLessonXTeacherRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model)
                {
                        this.LessonIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model)
                {
                        this.LessonIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>bf6effe4ed239ce58aaeed58b0a010f7</Hash>
</Codenesium>*/