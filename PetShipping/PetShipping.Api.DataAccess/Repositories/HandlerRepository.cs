using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class HandlerRepository: AbstractHandlerRepository, IHandlerRepository
	{
		public HandlerRepository(
			ILogger<HandlerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>cdaa6d8c6f30659c7f54424c74cfd84a</Hash>
</Codenesium>*/