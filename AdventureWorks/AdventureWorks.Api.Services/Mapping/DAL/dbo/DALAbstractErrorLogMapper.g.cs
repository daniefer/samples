using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractErrorLogMapper
	{
		public virtual ErrorLog MapBOToEF(
			BOErrorLog bo)
		{
			ErrorLog efErrorLog = new ErrorLog();
			efErrorLog.SetProperties(
				bo.ErrorLine,
				bo.ErrorLogID,
				bo.ErrorMessage,
				bo.ErrorNumber,
				bo.ErrorProcedure,
				bo.ErrorSeverity,
				bo.ErrorState,
				bo.ErrorTime,
				bo.UserName);
			return efErrorLog;
		}

		public virtual BOErrorLog MapEFToBO(
			ErrorLog ef)
		{
			var bo = new BOErrorLog();

			bo.SetProperties(
				ef.ErrorLogID,
				ef.ErrorLine,
				ef.ErrorMessage,
				ef.ErrorNumber,
				ef.ErrorProcedure,
				ef.ErrorSeverity,
				ef.ErrorState,
				ef.ErrorTime,
				ef.UserName);
			return bo;
		}

		public virtual List<BOErrorLog> MapEFToBO(
			List<ErrorLog> records)
		{
			List<BOErrorLog> response = new List<BOErrorLog>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>55190e9efb6333aa112a1c2e68194b67</Hash>
</Codenesium>*/