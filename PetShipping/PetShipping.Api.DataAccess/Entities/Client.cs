using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Client", Schema="dbo")]
	public partial class Client : AbstractEntity
	{
		public Client()
		{
		}

		public virtual void SetProperties(
			string email,
			string firstName,
			int id,
			string lastName,
			string notes,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
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

		[Column("notes")]
		public string Notes { get; private set; }

		[Column("phone")]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e6ea61864fcd5f31c769e34ef730a1f1</Hash>
</Codenesium>*/