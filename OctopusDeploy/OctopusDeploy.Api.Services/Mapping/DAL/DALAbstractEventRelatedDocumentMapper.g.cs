using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractEventRelatedDocumentMapper
	{
		public virtual EventRelatedDocument MapBOToEF(
			BOEventRelatedDocument bo)
		{
			EventRelatedDocument efEventRelatedDocument = new EventRelatedDocument();
			efEventRelatedDocument.SetProperties(
				bo.EventId,
				bo.Id,
				bo.RelatedDocumentId);
			return efEventRelatedDocument;
		}

		public virtual BOEventRelatedDocument MapEFToBO(
			EventRelatedDocument ef)
		{
			var bo = new BOEventRelatedDocument();

			bo.SetProperties(
				ef.Id,
				ef.EventId,
				ef.RelatedDocumentId);
			return bo;
		}

		public virtual List<BOEventRelatedDocument> MapEFToBO(
			List<EventRelatedDocument> records)
		{
			List<BOEventRelatedDocument> response = new List<BOEventRelatedDocument>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>44c0732d6c3b12588ad7995a44e66a87</Hash>
</Codenesium>*/