using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiCommunityActionTemplateResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			Guid externalId,
			string jSON,
			string name)
		{
			this.Id = id;
			this.ExternalId = externalId;
			this.JSON = jSON;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>94a52567f0698a51eca869d635cddb22</Hash>
</Codenesium>*/