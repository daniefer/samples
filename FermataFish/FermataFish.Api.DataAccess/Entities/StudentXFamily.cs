using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
        [Table("StudentXFamily", Schema="dbo")]
        public partial class StudentXFamily : AbstractEntity
        {
                public StudentXFamily()
                {
                }

                public virtual void SetProperties(
                        int familyId,
                        int id,
                        int studentId)
                {
                        this.FamilyId = familyId;
                        this.Id = id;
                        this.StudentId = studentId;
                }

                [Column("familyId")]
                public int FamilyId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("studentId")]
                public int StudentId { get; private set; }

                [ForeignKey("FamilyId")]
                public virtual Family FamilyNavigation { get; private set; }

                [ForeignKey("StudentId")]
                public virtual Student StudentNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b4af4dfee4bb2f1e1c654e071646ce9f</Hash>
</Codenesium>*/