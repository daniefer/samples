using Moq;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALBreedMapper DALBreedMapperMock { get; set; } = new DALBreedMapper();

		public IDALPaymentTypeMapper DALPaymentTypeMapperMock { get; set; } = new DALPaymentTypeMapper();

		public IDALPenMapper DALPenMapperMock { get; set; } = new DALPenMapper();

		public IDALPetMapper DALPetMapperMock { get; set; } = new DALPetMapper();

		public IDALSaleMapper DALSaleMapperMock { get; set; } = new DALSaleMapper();

		public IDALSpeciesMapper DALSpeciesMapperMock { get; set; } = new DALSpeciesMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c23401a12f845f09f8f14eff7c5bc80c</Hash>
</Codenesium>*/