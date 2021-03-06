using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiPersonRefResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int personAId,
			int personBId)
		{
			this.Id = id;
			this.PersonAId = personAId;
			this.PersonBId = personBId;

			this.PersonBIdEntity = nameof(ApiResponse.SchemaBPersons);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PersonAId { get; private set; }

		[JsonProperty]
		public int PersonBId { get; private set; }

		[JsonProperty]
		public string PersonBIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>258da785ac4161825db0f0ea49ca8878</Hash>
</Codenesium>*/