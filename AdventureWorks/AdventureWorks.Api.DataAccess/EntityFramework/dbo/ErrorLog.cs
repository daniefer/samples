using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class ErrorLog: AbstractEntityFrameworkPOCO
	{
		public ErrorLog()
		{}

		public void SetProperties(
			int errorLogID,
			Nullable<int> errorLine,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			Nullable<int> errorSeverity,
			Nullable<int> errorState,
			DateTime errorTime,
			string userName)
		{
			this.ErrorLine = errorLine.ToNullableInt();
			this.ErrorLogID = errorLogID.ToInt();
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorTime = errorTime.ToDateTime();
			this.UserName = userName;
		}

		[Column("ErrorLine", TypeName="int")]
		public Nullable<int> ErrorLine { get; set; }

		[Key]
		[Column("ErrorLogID", TypeName="int")]
		public int ErrorLogID { get; set; }

		[Column("ErrorMessage", TypeName="nvarchar(4000)")]
		public string ErrorMessage { get; set; }

		[Column("ErrorNumber", TypeName="int")]
		public int ErrorNumber { get; set; }

		[Column("ErrorProcedure", TypeName="nvarchar(126)")]
		public string ErrorProcedure { get; set; }

		[Column("ErrorSeverity", TypeName="int")]
		public Nullable<int> ErrorSeverity { get; set; }

		[Column("ErrorState", TypeName="int")]
		public Nullable<int> ErrorState { get; set; }

		[Column("ErrorTime", TypeName="datetime")]
		public DateTime ErrorTime { get; set; }

		[Column("UserName", TypeName="nvarchar(128)")]
		public string UserName { get; set; }
	}
}

/*<Codenesium>
    <Hash>81c79a0b0266d34f10b5a30913eefd06</Hash>
</Codenesium>*/