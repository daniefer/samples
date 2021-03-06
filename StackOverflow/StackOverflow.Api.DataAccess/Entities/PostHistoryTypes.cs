using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostHistoryTypes", Schema="dbo")]
	public partial class PostHistoryTypes : AbstractEntity
	{
		public PostHistoryTypes()
		{
		}

		public virtual void SetProperties(
			int id,
			string type)
		{
			this.Id = id;
			this.Type = type;
		}

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("Type")]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2c795684af1a029ec47ddad93e146da</Hash>
</Codenesium>*/