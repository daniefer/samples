using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOSpecies: AbstractPOCO
	{
		public POCOSpecies() : base()
		{}

		public POCOSpecies(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f9e10a77d4d0f834845fe1aa32db940b</Hash>
</Codenesium>*/