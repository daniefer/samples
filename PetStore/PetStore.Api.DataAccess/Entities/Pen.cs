using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStoreNS.Api.DataAccess
{
        [Table("Pen", Schema="dbo")]
        public partial class Pen : AbstractEntity
        {
                public Pen()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>222d07a1ce5053a956435accb6b61c71</Hash>
</Codenesium>*/