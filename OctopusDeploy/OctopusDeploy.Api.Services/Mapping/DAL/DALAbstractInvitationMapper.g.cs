using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractInvitationMapper
	{
		public virtual Invitation MapBOToEF(
			BOInvitation bo)
		{
			Invitation efInvitation = new Invitation();
			efInvitation.SetProperties(
				bo.Id,
				bo.InvitationCode,
				bo.JSON);
			return efInvitation;
		}

		public virtual BOInvitation MapEFToBO(
			Invitation ef)
		{
			var bo = new BOInvitation();

			bo.SetProperties(
				ef.Id,
				ef.InvitationCode,
				ef.JSON);
			return bo;
		}

		public virtual List<BOInvitation> MapEFToBO(
			List<Invitation> records)
		{
			List<BOInvitation> response = new List<BOInvitation>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5f39d0739c25722fd548dc6813a7045a</Hash>
</Codenesium>*/