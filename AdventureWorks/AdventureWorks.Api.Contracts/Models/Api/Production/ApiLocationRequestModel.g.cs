using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiLocationRequestModel : AbstractApiRequestModel
	{
		public ApiLocationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			double availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability;
			this.CostRate = costRate;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public double Availability { get; private set; }

		[Required]
		[JsonProperty]
		public decimal CostRate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9d20e7bb59f8b56641ce346798ab3b55</Hash>
</Codenesium>*/