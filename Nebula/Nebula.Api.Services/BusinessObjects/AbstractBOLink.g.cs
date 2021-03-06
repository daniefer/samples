using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOLink : AbstractBusinessObject
	{
		public AbstractBOLink()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int? assignedMachineId,
		                                  int chainId,
		                                  DateTime? dateCompleted,
		                                  DateTime? dateStarted,
		                                  string dynamicParameters,
		                                  Guid externalId,
		                                  int linkStatusId,
		                                  string name,
		                                  int order,
		                                  string response,
		                                  string staticParameters,
		                                  int timeoutInSeconds)
		{
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.Id = id;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds;
		}

		public int? AssignedMachineId { get; private set; }

		public int ChainId { get; private set; }

		public DateTime? DateCompleted { get; private set; }

		public DateTime? DateStarted { get; private set; }

		public string DynamicParameters { get; private set; }

		public Guid ExternalId { get; private set; }

		public int Id { get; private set; }

		public int LinkStatusId { get; private set; }

		public string Name { get; private set; }

		public int Order { get; private set; }

		public string Response { get; private set; }

		public string StaticParameters { get; private set; }

		public int TimeoutInSeconds { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7b841265b7ff47f0381ca3436f8844f0</Hash>
</Codenesium>*/