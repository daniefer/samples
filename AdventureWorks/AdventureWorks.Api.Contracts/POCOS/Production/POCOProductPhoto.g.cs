using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductPhoto: AbstractPOCO
	{
		public POCOProductPhoto() : base()
		{}

		public POCOProductPhoto(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductPhotoID = productPhotoID.ToInt();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		public byte[] LargePhoto { get; set; }
		public string LargePhotoFileName { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductPhotoID { get; set; }
		public byte[] ThumbNailPhoto { get; set; }
		public string ThumbnailPhotoFileName { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoValue { get; set; } = true;

		public bool ShouldSerializeLargePhoto()
		{
			return this.ShouldSerializeLargePhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoFileNameValue { get; set; } = true;

		public bool ShouldSerializeLargePhotoFileName()
		{
			return this.ShouldSerializeLargePhotoFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoIDValue { get; set; } = true;

		public bool ShouldSerializeProductPhotoID()
		{
			return this.ShouldSerializeProductPhotoIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbNailPhotoValue { get; set; } = true;

		public bool ShouldSerializeThumbNailPhoto()
		{
			return this.ShouldSerializeThumbNailPhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbnailPhotoFileNameValue { get; set; } = true;

		public bool ShouldSerializeThumbnailPhotoFileName()
		{
			return this.ShouldSerializeThumbnailPhotoFileNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeLargePhotoValue = false;
			this.ShouldSerializeLargePhotoFileNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductPhotoIDValue = false;
			this.ShouldSerializeThumbNailPhotoValue = false;
			this.ShouldSerializeThumbnailPhotoFileNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b8fa83ca47a0527b10513b9128214bf2</Hash>
</Codenesium>*/