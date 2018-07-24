using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
        [Table("Clasp", Schema="dbo")]
        public partial class Clasp : AbstractEntity
        {
                public Clasp()
                {
                }

                public virtual void SetProperties(
                        int id,
                        int nextChainId,
                        int previousChainId)
                {
                        this.Id = id;
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("nextChainId")]
                public int NextChainId { get; private set; }

                [Column("previousChainId")]
                public int PreviousChainId { get; private set; }

                [ForeignKey("NextChainId")]
                public virtual Chain ChainNavigation { get; private set; }

                [ForeignKey("PreviousChainId")]
                public virtual Chain Chain1Navigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ed455f3c234bf7f074069dde060e3e8e</Hash>
</Codenesium>*/