using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiAccountResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string accountType,
			string environmentIds,
			string jSON,
			string name,
			string tenantIds,
			string tenantTags)
		{
			this.Id = id;
			this.AccountType = accountType;
			this.EnvironmentIds = environmentIds;
			this.JSON = jSON;
			this.Name = name;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
		}

		[Required]
		[JsonProperty]
		public string AccountType { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentIds { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantIds { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>91f7309d9c0a55c9269ab9bf8640d7b8</Hash>
</Codenesium>*/