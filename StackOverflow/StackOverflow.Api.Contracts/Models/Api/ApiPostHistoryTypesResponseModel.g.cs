using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiPostHistoryTypesResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string type)
		{
			this.Id = id;
			this.Type = type;
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a083a890140828757cfab0169029bae6</Hash>
</Codenesium>*/