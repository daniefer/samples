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
	[Trait("Table", "Lifecycle")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLifecycleRequestModelValidatorTest
	{
		public ApiLifecycleRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);
			await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiLifecycleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(new Lifecycle()));
			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

			await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

			await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(new Lifecycle()));
			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiLifecycleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
			lifecycleRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
			var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiLifecycleRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>3e235089c0fc5387d93f2b4132ea3b39</Hash>
</Codenesium>*/