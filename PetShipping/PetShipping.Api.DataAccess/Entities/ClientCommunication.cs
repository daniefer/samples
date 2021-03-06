using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("ClientCommunication", Schema="dbo")]
	public partial class ClientCommunication : AbstractEntity
	{
		public ClientCommunication()
		{
		}

		public virtual void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			int id,
			string notes)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Notes = notes;
		}

		[Column("clientId")]
		public int ClientId { get; private set; }

		[Column("dateCreated")]
		public DateTime DateCreated { get; private set; }

		[Column("employeeId")]
		public int EmployeeId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("notes")]
		public string Notes { get; private set; }

		[ForeignKey("ClientId")]
		public virtual Client ClientNavigation { get; private set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2229f2eeef2a80daaf3ffcaaee40af73</Hash>
</Codenesium>*/