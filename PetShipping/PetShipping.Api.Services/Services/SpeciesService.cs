using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolspeciesMapper,
			IDALSpeciesMapper dalspeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper
			)
			: base(logger,
			       speciesRepository,
			       speciesModelValidator,
			       bolspeciesMapper,
			       dalspeciesMapper,
			       bolBreedMapper,
			       dalBreedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>36362d1381ecbedd72d14af2c389b6f0</Hash>
</Codenesium>*/