using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOCertificate : AbstractBusinessObject
	{
		public AbstractBOCertificate()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  DateTimeOffset? archived,
		                                  DateTimeOffset created,
		                                  byte[] dataVersion,
		                                  string environmentIds,
		                                  string jSON,
		                                  string name,
		                                  DateTimeOffset notAfter,
		                                  string subject,
		                                  string tenantIds,
		                                  string tenantTags,
		                                  string thumbprint)
		{
			this.Archived = archived;
			this.Created = created;
			this.DataVersion = dataVersion;
			this.EnvironmentIds = environmentIds;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.NotAfter = notAfter;
			this.Subject = subject;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
			this.Thumbprint = thumbprint;
		}

		public DateTimeOffset? Archived { get; private set; }

		public DateTimeOffset Created { get; private set; }

		public byte[] DataVersion { get; private set; }

		public string EnvironmentIds { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public DateTimeOffset NotAfter { get; private set; }

		public string Subject { get; private set; }

		public string TenantIds { get; private set; }

		public string TenantTags { get; private set; }

		public string Thumbprint { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cecb7d7e96641bff8afa26d7e08e5f39</Hash>
</Codenesium>*/