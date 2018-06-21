using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Admin", Schema="dbo")]
        public partial class Admin : AbstractEntity
        {
                public Admin()
                {
                }

                public void SetProperties(
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
                }

                [Column("email")]
                public string Email { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("password")]
                public string Password { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("username")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8852fb8fa3c11eb9e181ff95e6cde471</Hash>
</Codenesium>*/