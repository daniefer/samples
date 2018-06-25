using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Teacher", Schema="dbo")]
        public partial class Teacher : AbstractEntity
        {
                public Teacher()
                {
                }

                public virtual void SetProperties(
                        DateTime birthday,
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone,
                        int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;
                }

                [Column("birthday")]
                public DateTime Birthday { get; private set; }

                [Column("email")]
                public string Email { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>c0191b98b33dfde0a57232a943266976</Hash>
</Codenesium>*/