using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Tags")]
        [Trait("Area", "DALMapper")]
        public class TestDALTagsMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTagsMapper();
                        var bo = new BOTags();
                        bo.SetProperties(1, 1, 1, "A", 1);

                        Tags response = mapper.MapBOToEF(bo);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTagsMapper();
                        Tags entity = new Tags();
                        entity.SetProperties(1, 1, 1, "A", 1);

                        BOTags response = mapper.MapEFToBO(entity);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTagsMapper();
                        Tags entity = new Tags();
                        entity.SetProperties(1, 1, 1, "A", 1);

                        List<BOTags> response = mapper.MapEFToBO(new List<Tags>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>30cab8e0a4cd89f383488f9e2a9619a3</Hash>
</Codenesium>*/