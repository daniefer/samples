using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ContactType", Schema="Person")]
        public partial class ContactType : AbstractEntity
        {
                public ContactType()
                {
                }

                public virtual void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("ContactTypeID")]
                public int ContactTypeID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4803620f1ed9fd2b7c31128ab5eb6dcf</Hash>
</Codenesium>*/