using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("Family", Schema="dbo")]
	public partial class EFFamily
	{
		public EFFamily()
		{}

		public void SetProperties(
			int id,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			string pcEmail,
			string notes,
			int studioId)
		{
			this.Id = id.ToInt();
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.PcEmail = pcEmail;
			this.Notes = notes;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pcFirstName", TypeName="varchar(128)")]
		public string PcFirstName { get; set; }

		[Column("pcLastName", TypeName="varchar(128)")]
		public string PcLastName { get; set; }

		[Column("pcPhone", TypeName="varchar(128)")]
		public string PcPhone { get; set; }

		[Column("pcEmail", TypeName="varchar(128)")]
		public string PcEmail { get; set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("Id")]
		public virtual EFStudio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>53e38c32cbd6b1b45a9f0a15d2401939</Hash>
</Codenesium>*/