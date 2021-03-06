using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOActionTemplateVersion : AbstractBusinessObject
	{
		public AbstractBOActionTemplateVersion()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string actionType,
		                                  string jSON,
		                                  string latestActionTemplateId,
		                                  string name,
		                                  int version)
		{
			this.ActionType = actionType;
			this.Id = id;
			this.JSON = jSON;
			this.LatestActionTemplateId = latestActionTemplateId;
			this.Name = name;
			this.Version = version;
		}

		public string ActionType { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string LatestActionTemplateId { get; private set; }

		public string Name { get; private set; }

		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fb6eb273b355d6e45c05a8b20234af97</Hash>
</Codenesium>*/