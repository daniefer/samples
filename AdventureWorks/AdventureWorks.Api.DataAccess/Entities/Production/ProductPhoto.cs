using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class ProductPhoto : AbstractEntity
	{
		public ProductPhoto()
		{
		}

		public virtual void SetProperties(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate;
			this.ProductPhotoID = productPhotoID;
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		[Column("LargePhoto")]
		public byte[] LargePhoto { get; private set; }

		[Column("LargePhotoFileName")]
		public string LargePhotoFileName { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductPhotoID")]
		public int ProductPhotoID { get; private set; }

		[Column("ThumbNailPhoto")]
		public byte[] ThumbNailPhoto { get; private set; }

		[Column("ThumbnailPhotoFileName")]
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>94753bd7a58c17e9c6595d636bfa790f</Hash>
</Codenesium>*/