using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiPersonResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int personId,
			string personName)
		{
			this.PersonId = personId;
			this.PersonName = personName;
		}

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>236dd4ff98460161cfc07c06eee0d2d0</Hash>
</Codenesium>*/