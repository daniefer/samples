using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTerritoryHistoryRequestModel: AbstractApiRequestModel
	{
		public ApiSalesTerritoryHistoryRequestModel() : base()
		{}

		public void SetProperties(
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			int territoryID)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.StartDate = startDate.ToDateTime();
			this.TerritoryID = territoryID.ToInt();
		}

		private Nullable<DateTime> endDate;

		public Nullable<DateTime> EndDate
		{
			get
			{
				return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
			}

			set
			{
				this.endDate = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}

		private int territoryID;

		[Required]
		public int TerritoryID
		{
			get
			{
				return this.territoryID;
			}

			set
			{
				this.territoryID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8a0f709e4fff6b6299dfa7a21ef742f0</Hash>
</Codenesium>*/