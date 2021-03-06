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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSchemaAPersonRequestModelValidatorTest
	{
		public ApiSchemaAPersonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISchemaAPersonRepository> schemaAPersonRepository = new Mock<ISchemaAPersonRepository>();
			schemaAPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));

			var validator = new ApiSchemaAPersonRequestModelValidator(schemaAPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSchemaAPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISchemaAPersonRepository> schemaAPersonRepository = new Mock<ISchemaAPersonRepository>();
			schemaAPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));

			var validator = new ApiSchemaAPersonRequestModelValidator(schemaAPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSchemaAPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISchemaAPersonRepository> schemaAPersonRepository = new Mock<ISchemaAPersonRepository>();
			schemaAPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));

			var validator = new ApiSchemaAPersonRequestModelValidator(schemaAPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSchemaAPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISchemaAPersonRepository> schemaAPersonRepository = new Mock<ISchemaAPersonRepository>();
			schemaAPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));

			var validator = new ApiSchemaAPersonRequestModelValidator(schemaAPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSchemaAPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>026317f8f6e5c932474851fa813940ab</Hash>
</Codenesium>*/