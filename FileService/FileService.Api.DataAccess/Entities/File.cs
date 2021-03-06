using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
	[Table("File", Schema="dbo")]
	public partial class File : AbstractEntity
	{
		public File()
		{
		}

		public virtual void SetProperties(
			int? bucketId,
			DateTime dateCreated,
			string description,
			DateTime expiration,
			string extension,
			Guid externalId,
			decimal fileSizeInBytes,
			int fileTypeId,
			int id,
			string location,
			string privateKey,
			string publicKey)
		{
			this.BucketId = bucketId;
			this.DateCreated = dateCreated;
			this.Description = description;
			this.Expiration = expiration;
			this.Extension = extension;
			this.ExternalId = externalId;
			this.FileSizeInBytes = fileSizeInBytes;
			this.FileTypeId = fileTypeId;
			this.Id = id;
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
		}

		[Column("bucketId")]
		public int? BucketId { get; private set; }

		[Column("dateCreated")]
		public DateTime DateCreated { get; private set; }

		[Column("description")]
		public string Description { get; private set; }

		[Column("expiration")]
		public DateTime Expiration { get; private set; }

		[Column("extension")]
		public string Extension { get; private set; }

		[Column("externalId")]
		public Guid ExternalId { get; private set; }

		[Column("fileSizeInBytes")]
		public decimal FileSizeInBytes { get; private set; }

		[Column("fileTypeId")]
		public int FileTypeId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("location")]
		public string Location { get; private set; }

		[Column("privateKey")]
		public string PrivateKey { get; private set; }

		[Column("publicKey")]
		public string PublicKey { get; private set; }

		[ForeignKey("BucketId")]
		public virtual Bucket BucketNavigation { get; private set; }

		[ForeignKey("FileTypeId")]
		public virtual FileType FileTypeNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5bdec86302eefb09d4a3b21e337cb376</Hash>
</Codenesium>*/