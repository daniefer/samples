using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
	[Route("api/lessonXTeachers")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LessonXTeacherController : AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ApiSettings settings,
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherService lessonXTeacherService,
			IApiLessonXTeacherModelMapper lessonXTeacherModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonXTeacherService,
			       lessonXTeacherModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>83581c1d79a0f66d11f3e9e9c3a12773</Hash>
</Codenesium>*/