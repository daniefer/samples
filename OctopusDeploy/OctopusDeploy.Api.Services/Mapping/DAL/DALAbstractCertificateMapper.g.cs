using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractCertificateMapper
	{
		public virtual Certificate MapBOToEF(
			BOCertificate bo)
		{
			Certificate efCertificate = new Certificate();
			efCertificate.SetProperties(
				bo.Archived,
				bo.Created,
				bo.DataVersion,
				bo.EnvironmentIds,
				bo.Id,
				bo.JSON,
				bo.Name,
				bo.NotAfter,
				bo.Subject,
				bo.TenantIds,
				bo.TenantTags,
				bo.Thumbprint);
			return efCertificate;
		}

		public virtual BOCertificate MapEFToBO(
			Certificate ef)
		{
			var bo = new BOCertificate();

			bo.SetProperties(
				ef.Id,
				ef.Archived,
				ef.Created,
				ef.DataVersion,
				ef.EnvironmentIds,
				ef.JSON,
				ef.Name,
				ef.NotAfter,
				ef.Subject,
				ef.TenantIds,
				ef.TenantTags,
				ef.Thumbprint);
			return bo;
		}

		public virtual List<BOCertificate> MapEFToBO(
			List<Certificate> records)
		{
			List<BOCertificate> response = new List<BOCertificate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc8693d8df505b5c257b9f73ac63fae3</Hash>
</Codenesium>*/