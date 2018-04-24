using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Link", Schema="dbo")]
	public partial class EFLink:AbstractEntityFrameworkPOCO
	{
		public EFLink()
		{}

		public void SetProperties(
			int id,
			string name,
			string dynamicParameters,
			string staticParameters,
			int chainId,
			Nullable<int> assignedMachineId,
			int linkStatusId,
			int order,
			Nullable<DateTime> dateStarted,
			Nullable<DateTime> dateCompleted,
			string response,
			Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.DynamicParameters = dynamicParameters.ToString();
			this.StaticParameters = staticParameters.ToString();
			this.ChainId = chainId.ToInt();
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Order = order.ToInt();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.Response = response.ToString();
			this.ExternalId = externalId.ToGuid();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("dynamicParameters", TypeName="text(2147483647)")]
		public string DynamicParameters { get; set; }

		[Column("staticParameters", TypeName="text(2147483647)")]
		public string StaticParameters { get; set; }

		[Column("chainId", TypeName="int")]
		public int ChainId { get; set; }

		[Column("assignedMachineId", TypeName="int")]
		public Nullable<int> AssignedMachineId { get; set; }

		[Column("linkStatusId", TypeName="int")]
		public int LinkStatusId { get; set; }

		[Column("order", TypeName="int")]
		public int Order { get; set; }

		[Column("dateStarted", TypeName="datetime")]
		public Nullable<DateTime> DateStarted { get; set; }

		[Column("dateCompleted", TypeName="datetime")]
		public Nullable<DateTime> DateCompleted { get; set; }

		[Column("response", TypeName="text(2147483647)")]
		public string Response { get; set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }

		[ForeignKey("ChainId")]
		public virtual EFChain Chain { get; set; }

		[ForeignKey("AssignedMachineId")]
		public virtual EFMachine Machine { get; set; }

		[ForeignKey("LinkStatusId")]
		public virtual EFLinkStatus LinkStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>75b8f053d0b65a2298162caf93a60f36</Hash>
</Codenesium>*/