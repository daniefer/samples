using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiWorkerPoolRequestModel : AbstractApiRequestModel
	{
		public ApiWorkerPoolRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isDefault,
			string jSON,
			string name,
			int sortOrder)
		{
			this.IsDefault = isDefault;
			this.JSON = jSON;
			this.Name = name;
			this.SortOrder = sortOrder;
		}

		[JsonProperty]
		public bool IsDefault { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int SortOrder { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5479d5db79cdc5aaac1aac156fbb5bcd</Hash>
</Codenesium>*/