using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeeDepartmentHistoryResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			short departmentID,
			DateTime? endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.DepartmentID = departmentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public short DepartmentID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ShiftID { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a9a3eb81f26e4d009a1b7ad843a10200</Hash>
</Codenesium>*/