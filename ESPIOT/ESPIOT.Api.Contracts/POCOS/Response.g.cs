using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ESPIOTNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "V")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "O")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class Response
	{
		public Response()
		{}
		public List<POCODevice> Devices { get; private set; } = new List<POCODevice>();

		public List<POCODeviceAction> DeviceActions { get; private set; } = new List<POCODeviceAction>();

		[JsonIgnore]
		public bool ShouldSerializeDevicesValue { get; set; } = true;

		public bool ShouldSerializeDevices()
		{
			return this.ShouldSerializeDevicesValue;
		}

		public void AddDevice(POCODevice item)
		{
			if (!this.Devices.Any(x => x.Id == item.Id))
			{
				this.Devices.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeDeviceActionsValue { get; set; } = true;

		public bool ShouldSerializeDeviceActions()
		{
			return this.ShouldSerializeDeviceActionsValue;
		}

		public void AddDeviceAction(POCODeviceAction item)
		{
			if (!this.DeviceActions.Any(x => x.Id == item.Id))
			{
				this.DeviceActions.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Devices.Count == 0)
			{
				this.ShouldSerializeDevicesValue = false;
			}

			if (this.DeviceActions.Count == 0)
			{
				this.ShouldSerializeDeviceActionsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d8a80b0379254b8e8b4568ea71c8436e</Hash>
</Codenesium>*/