using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiJobCandidateRequestModelValidatorTest
	{
		public ApiJobCandidateRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6fb0601f934ba8d370f234e92ac2f7a</Hash>
</Codenesium>*/