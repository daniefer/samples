using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRefTeamModel: AbstractModel
	{
		public ApiMachineRefTeamModel() : base()
		{}

		public ApiMachineRefTeamModel(
			int machineId,
			int teamId)
		{
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		private int machineId;

		[Required]
		public int MachineId
		{
			get
			{
				return this.machineId;
			}

			set
			{
				this.machineId = value;
			}
		}

		private int teamId;

		[Required]
		public int TeamId
		{
			get
			{
				return this.teamId;
			}

			set
			{
				this.teamId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>afafbe56ded7d7f673c0f107f6df29bd</Hash>
</Codenesium>*/