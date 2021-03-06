using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiJobCandidateResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int jobCandidateID,
			int? businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.JobCandidateID = jobCandidateID;
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		[Required]
		[JsonProperty]
		public int? BusinessEntityID { get; private set; }

		[JsonProperty]
		public int JobCandidateID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ec157e035d84d997ee0684b28f4392b8</Hash>
</Codenesium>*/