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
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiKeyAllocationRequestModelValidatorTest
	{
		public ApiKeyAllocationRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6d387c632e585152dd81420fc52ad71</Hash>
</Codenesium>*/