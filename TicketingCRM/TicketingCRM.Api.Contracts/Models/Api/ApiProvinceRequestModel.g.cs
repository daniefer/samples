using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiProvinceRequestModel : AbstractApiRequestModel
	{
		public ApiProvinceRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string name)
		{
			this.CountryId = countryId;
			this.Name = name;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>aff415fde20b4d7515530f04ec235589</Hash>
</Codenesium>*/