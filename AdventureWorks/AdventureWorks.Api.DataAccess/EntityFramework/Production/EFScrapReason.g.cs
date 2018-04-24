using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ScrapReason", Schema="Production")]
	public partial class EFScrapReason: AbstractEntityFrameworkPOCO
	{
		public EFScrapReason()
		{}

		public void SetProperties(
			short scrapReasonID,
			string name,
			DateTime modifiedDate)
		{
			this.ScrapReasonID = scrapReasonID;
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ScrapReasonID", TypeName="smallint")]
		public short ScrapReasonID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>12cddfbd9b3c412482b9a92f26cec70e</Hash>
</Codenesium>*/