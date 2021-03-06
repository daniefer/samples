using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractUserRoleMapper
	{
		public virtual UserRole MapBOToEF(
			BOUserRole bo)
		{
			UserRole efUserRole = new UserRole();
			efUserRole.SetProperties(
				bo.Id,
				bo.JSON,
				bo.Name);
			return efUserRole;
		}

		public virtual BOUserRole MapEFToBO(
			UserRole ef)
		{
			var bo = new BOUserRole();

			bo.SetProperties(
				ef.Id,
				ef.JSON,
				ef.Name);
			return bo;
		}

		public virtual List<BOUserRole> MapEFToBO(
			List<UserRole> records)
		{
			List<BOUserRole> response = new List<BOUserRole>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>047640642eb72de90a4d986d20c5b547</Hash>
</Codenesium>*/