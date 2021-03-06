using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
	public partial class LessonStatusService : AbstractLessonStatusService, ILessonStatusService
	{
		public LessonStatusService(
			ILogger<ILessonStatusRepository> logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper bollessonStatusMapper,
			IDALLessonStatusMapper dallessonStatusMapper,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper
			)
			: base(logger,
			       lessonStatusRepository,
			       lessonStatusModelValidator,
			       bollessonStatusMapper,
			       dallessonStatusMapper,
			       bolLessonMapper,
			       dalLessonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7b9e554003ea5095eb30f57ec4973ab6</Hash>
</Codenesium>*/