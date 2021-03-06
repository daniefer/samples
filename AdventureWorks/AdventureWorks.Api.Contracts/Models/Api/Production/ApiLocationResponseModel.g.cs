using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiLocationResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			short locationID,
			double availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.LocationID = locationID;
			this.Availability = availability;
			this.CostRate = costRate;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public double Availability { get; private set; }

		[JsonProperty]
		public decimal CostRate { get; private set; }

		[JsonProperty]
		public short LocationID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f3fababcb6197aedfbb275f653edc91b</Hash>
</Codenesium>*/