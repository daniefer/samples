using Moq;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;

namespace TestsNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALPersonMapper DALPersonMapperMock { get; set; } = new DALPersonMapper();

		public IDALRowVersionCheckMapper DALRowVersionCheckMapperMock { get; set; } = new DALRowVersionCheckMapper();

		public IDALSelfReferenceMapper DALSelfReferenceMapperMock { get; set; } = new DALSelfReferenceMapper();

		public IDALTableMapper DALTableMapperMock { get; set; } = new DALTableMapper();

		public IDALTestAllFieldTypeMapper DALTestAllFieldTypeMapperMock { get; set; } = new DALTestAllFieldTypeMapper();

		public IDALTestAllFieldTypesNullableMapper DALTestAllFieldTypesNullableMapperMock { get; set; } = new DALTestAllFieldTypesNullableMapper();

		public IDALTimestampCheckMapper DALTimestampCheckMapperMock { get; set; } = new DALTimestampCheckMapper();

		public IDALSchemaAPersonMapper DALSchemaAPersonMapperMock { get; set; } = new DALSchemaAPersonMapper();

		public IDALSchemaBPersonMapper DALSchemaBPersonMapperMock { get; set; } = new DALSchemaBPersonMapper();

		public IDALPersonRefMapper DALPersonRefMapperMock { get; set; } = new DALPersonRefMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f04e631f1d28b6c9754ac70474ddf029</Hash>
</Codenesium>*/