using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class EFDeviceAction: AbstractEntityFrameworkPOCO
	{
		public EFDeviceAction()
		{}

		public void SetProperties(
			int id,
			int deviceId,
			string name,
			string @value)
		{
			this.Id = id.ToInt();
			this.DeviceId = deviceId.ToInt();
			this.Name = name.ToString();
			this.@Value = @value.ToString();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("deviceId", TypeName="int")]
		public int DeviceId { get; set; }

		[Column("name", TypeName="varchar(90)")]
		public string Name { get; set; }

		[Column("value", TypeName="varchar(4000)")]
		public string @Value { get; set; }

		[ForeignKey("DeviceId")]
		public virtual EFDevice Device { get; set; }
	}
}

/*<Codenesium>
    <Hash>34ed85e19cd37e0237556277c2340d22</Hash>
</Codenesium>*/