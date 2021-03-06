using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractAWBuildVersionMapper
	{
		public virtual AWBuildVersion MapBOToEF(
			BOAWBuildVersion bo)
		{
			AWBuildVersion efAWBuildVersion = new AWBuildVersion();
			efAWBuildVersion.SetProperties(
				bo.Database_Version,
				bo.ModifiedDate,
				bo.SystemInformationID,
				bo.VersionDate);
			return efAWBuildVersion;
		}

		public virtual BOAWBuildVersion MapEFToBO(
			AWBuildVersion ef)
		{
			var bo = new BOAWBuildVersion();

			bo.SetProperties(
				ef.SystemInformationID,
				ef.Database_Version,
				ef.ModifiedDate,
				ef.VersionDate);
			return bo;
		}

		public virtual List<BOAWBuildVersion> MapEFToBO(
			List<AWBuildVersion> records)
		{
			List<BOAWBuildVersion> response = new List<BOAWBuildVersion>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d46f1432804b82a9a2a2c09387254fb2</Hash>
</Codenesium>*/