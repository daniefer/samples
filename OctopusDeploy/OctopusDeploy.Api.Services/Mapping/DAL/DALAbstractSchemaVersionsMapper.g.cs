using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractSchemaVersionsMapper
	{
		public virtual SchemaVersions MapBOToEF(
			BOSchemaVersions bo)
		{
			SchemaVersions efSchemaVersions = new SchemaVersions();
			efSchemaVersions.SetProperties(
				bo.Applied,
				bo.Id,
				bo.ScriptName);
			return efSchemaVersions;
		}

		public virtual BOSchemaVersions MapEFToBO(
			SchemaVersions ef)
		{
			var bo = new BOSchemaVersions();

			bo.SetProperties(
				ef.Id,
				ef.Applied,
				ef.ScriptName);
			return bo;
		}

		public virtual List<BOSchemaVersions> MapEFToBO(
			List<SchemaVersions> records)
		{
			List<BOSchemaVersions> response = new List<BOSchemaVersions>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>48b04a8f5c32e424cfe4901adf7e98bb</Hash>
</Codenesium>*/