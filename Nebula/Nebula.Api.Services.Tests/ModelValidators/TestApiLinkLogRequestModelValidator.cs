using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkLogRequestModelValidatorTest
	{
		public ApiLinkLogRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LinkId_Create_Valid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.GetLink(It.IsAny<int>())).Returns(Task.FromResult<Link>(new Link()));

			var validator = new ApiLinkLogRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkLogRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Create_Invalid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.GetLink(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));

			var validator = new ApiLinkLogRequestModelValidator(linkLogRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Update_Valid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.GetLink(It.IsAny<int>())).Returns(Task.FromResult<Link>(new Link()));

			var validator = new ApiLinkLogRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkLogRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Update_Invalid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.GetLink(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));

			var validator = new ApiLinkLogRequestModelValidator(linkLogRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>31d769fdf17f25473946d7bb689f3faa</Hash>
</Codenesium>*/