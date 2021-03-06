using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOErrorLog : AbstractBusinessObject
	{
		public AbstractBOErrorLog()
			: base()
		{
		}

		public virtual void SetProperties(int errorLogID,
		                                  int? errorLine,
		                                  string errorMessage,
		                                  int errorNumber,
		                                  string errorProcedure,
		                                  int? errorSeverity,
		                                  int? errorState,
		                                  DateTime errorTime,
		                                  string userName)
		{
			this.ErrorLine = errorLine;
			this.ErrorLogID = errorLogID;
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber;
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity;
			this.ErrorState = errorState;
			this.ErrorTime = errorTime;
			this.UserName = userName;
		}

		public int? ErrorLine { get; private set; }

		public int ErrorLogID { get; private set; }

		public string ErrorMessage { get; private set; }

		public int ErrorNumber { get; private set; }

		public string ErrorProcedure { get; private set; }

		public int? ErrorSeverity { get; private set; }

		public int? ErrorState { get; private set; }

		public DateTime ErrorTime { get; private set; }

		public string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>89ddd274dca5937a426f81fb4991b8cf</Hash>
</Codenesium>*/