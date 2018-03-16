using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkModel
	{
		public LinkModel()
		{}

		public LinkModel(Nullable<int> assignedMachineId,
		                 int chainId,
		                 Nullable<DateTime> dateCompleted,
		                 Nullable<DateTime> dateStarted,
		                 string dynamicParameters,
		                 Guid externalId,
		                 int linkStatusId,
		                 string name,
		                 int order,
		                 string response,
		                 string staticParameters)
		{
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.ChainId = chainId.ToInt();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.LinkStatusId = linkStatusId.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
			this.Response = response;
			this.StaticParameters = staticParameters;
		}

		public LinkModel(POCOLink poco)
		{
			this.DateCompleted = poco.DateCompleted.ToNullableDateTime();
			this.DateStarted = poco.DateStarted.ToNullableDateTime();
			this.DynamicParameters = poco.DynamicParameters;
			this.ExternalId = poco.ExternalId;
			this.Name = poco.Name;
			this.Order = poco.Order.ToInt();
			this.Response = poco.Response;
			this.StaticParameters = poco.StaticParameters;

			this.AssignedMachineId = poco.AssignedMachineId.Value.ToInt();
			this.ChainId = poco.ChainId.Value.ToInt();
			this.LinkStatusId = poco.LinkStatusId.Value.ToInt();
		}

		private Nullable<int> _assignedMachineId;
		public Nullable<int> AssignedMachineId
		{
			get
			{
				return _assignedMachineId.IsEmptyOrZeroOrNull() ? null : _assignedMachineId;
			}
			set
			{
				this._assignedMachineId = value;
			}
		}

		private int _chainId;
		[Required]
		public int ChainId
		{
			get
			{
				return _chainId;
			}
			set
			{
				this._chainId = value;
			}
		}

		private Nullable<DateTime> _dateCompleted;
		public Nullable<DateTime> DateCompleted
		{
			get
			{
				return _dateCompleted.IsEmptyOrZeroOrNull() ? null : _dateCompleted;
			}
			set
			{
				this._dateCompleted = value;
			}
		}

		private Nullable<DateTime> _dateStarted;
		public Nullable<DateTime> DateStarted
		{
			get
			{
				return _dateStarted.IsEmptyOrZeroOrNull() ? null : _dateStarted;
			}
			set
			{
				this._dateStarted = value;
			}
		}

		private string _dynamicParameters;
		public string DynamicParameters
		{
			get
			{
				return _dynamicParameters.IsEmptyOrZeroOrNull() ? null : _dynamicParameters;
			}
			set
			{
				this._dynamicParameters = value;
			}
		}

		private Guid _externalId;
		[Required]
		public Guid ExternalId
		{
			get
			{
				return _externalId;
			}
			set
			{
				this._externalId = value;
			}
		}

		private int _linkStatusId;
		[Required]
		public int LinkStatusId
		{
			get
			{
				return _linkStatusId;
			}
			set
			{
				this._linkStatusId = value;
			}
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private int _order;
		[Required]
		public int Order
		{
			get
			{
				return _order;
			}
			set
			{
				this._order = value;
			}
		}

		private string _response;
		public string Response
		{
			get
			{
				return _response.IsEmptyOrZeroOrNull() ? null : _response;
			}
			set
			{
				this._response = value;
			}
		}

		private string _staticParameters;
		public string StaticParameters
		{
			get
			{
				return _staticParameters.IsEmptyOrZeroOrNull() ? null : _staticParameters;
			}
			set
			{
				this._staticParameters = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ebb48f36c711c8499475df40b22e5388</Hash>
</Codenesium>*/