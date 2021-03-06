using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiUserRoleRequestModel : AbstractApiRequestModel
	{
		public ApiUserRoleRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string jSON,
			string name)
		{
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>68fce3336d8bea66f060f3480f9ffe47</Hash>
</Codenesium>*/