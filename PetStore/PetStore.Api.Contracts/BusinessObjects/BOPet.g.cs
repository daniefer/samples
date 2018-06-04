using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class BOPet:AbstractBusinessObject
	{
		public BOPet() : base()
		{}

		public void SetProperties(int id,
		                          DateTime acquiredDate,
		                          int breedId,
		                          string description,
		                          int penId,
		                          decimal price,
		                          int speciesId)
		{
			this.AcquiredDate = acquiredDate.ToDateTime();
			this.BreedId = breedId.ToInt();
			this.Description = description;
			this.Id = id.ToInt();
			this.PenId = penId.ToInt();
			this.Price = price.ToDecimal();
			this.SpeciesId = speciesId.ToInt();
		}

		public DateTime AcquiredDate { get; private set; }
		public int BreedId { get; private set; }
		public string Description { get; private set; }
		public int Id { get; private set; }
		public int PenId { get; private set; }
		public decimal Price { get; private set; }
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6bcae48835ec27563cd3f6b9a8c17ab7</Hash>
</Codenesium>*/