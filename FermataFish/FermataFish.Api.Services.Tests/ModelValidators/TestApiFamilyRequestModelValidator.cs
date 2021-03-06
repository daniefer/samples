using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFamilyRequestModelValidatorTest
	{
		public ApiFamilyRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PcEmail_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcEmail, new string('A', 129));
		}

		[Fact]
		public async void PcEmail_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcEmail, new string('A', 129));
		}

		[Fact]
		public async void PcFirstName_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcFirstName, new string('A', 129));
		}

		[Fact]
		public async void PcFirstName_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcFirstName, new string('A', 129));
		}

		[Fact]
		public async void PcLastName_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcLastName, new string('A', 129));
		}

		[Fact]
		public async void PcLastName_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcLastName, new string('A', 129));
		}

		[Fact]
		public async void PcPhone_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcPhone, new string('A', 129));
		}

		[Fact]
		public async void PcPhone_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PcPhone, new string('A', 129));
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);

			await validator.ValidateCreateAsync(new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiFamilyRequestModelValidator(familyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>50c8d89044303262cb11980de44c7d8c</Hash>
</Codenesium>*/