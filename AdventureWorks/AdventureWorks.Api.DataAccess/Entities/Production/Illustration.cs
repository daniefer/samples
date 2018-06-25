using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Illustration", Schema="Production")]
        public partial class Illustration : AbstractEntity
        {
                public Illustration()
                {
                }

                public virtual void SetProperties(
                        string diagram,
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                [Column("Diagram")]
                public string Diagram { get; private set; }

                [Key]
                [Column("IllustrationID")]
                public int IllustrationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>91ef997c19ff54c98d54ebe376ce4d11</Hash>
</Codenesium>*/