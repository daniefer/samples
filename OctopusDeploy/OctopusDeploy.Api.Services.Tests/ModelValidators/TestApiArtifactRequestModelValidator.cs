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
	[Trait("Table", "Artifact")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiArtifactRequestModelValidatorTest
	{
		public ApiArtifactRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EnvironmentId_Create_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
		}

		[Fact]
		public async void EnvironmentId_Update_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
		}

		[Fact]
		public async void Filename_Create_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Filename, new string('A', 201));
		}

		[Fact]
		public async void Filename_Update_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Filename, new string('A', 201));
		}

		[Fact]
		public async void ProjectId_Create_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
		}

		[Fact]
		public async void ProjectId_Update_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
		}

		[Fact]
		public async void TenantId_Create_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
		}

		[Fact]
		public async void TenantId_Update_length()
		{
			Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
			artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

			var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiArtifactRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>7daf0c78ea141a2bfa897e86f3396477</Hash>
</Codenesium>*/