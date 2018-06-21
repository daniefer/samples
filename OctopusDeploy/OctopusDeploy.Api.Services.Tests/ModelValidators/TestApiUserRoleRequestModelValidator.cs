using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "UserRole")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiUserRoleRequestModelValidatorTest
        {
                public ApiUserRoleRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));

                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(new UserRole()));
                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(null));
                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRoleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(new UserRole()));
                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiUserRoleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IUserRoleRepository> userRoleRepository = new Mock<IUserRoleRepository>();
                        userRoleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(null));
                        var validator = new ApiUserRoleRequestModelValidator(userRoleRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiUserRoleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>3773b5c87848c7a209ea949b6aac0ee3</Hash>
</Codenesium>*/