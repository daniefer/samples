using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace FileServiceNS.Api.Contracts
{
	[Table("File", Schema="dbo")]
	public partial class File
	{
		public File()
		{}

		public Nullable<int> bucketId {get; set;}
		public DateTime dateCreated {get; set;}
		public string description {get; set;}
		public DateTime expiration {get; set;}
		public string extension {get; set;}
		public Guid externalId {get; set;}
		public decimal fileSizeInBytes {get; set;}
		public int fileTypeId {get; set;}
		[Key]
		public int id {get; set;}
		public string location {get; set;}
		public string privateKey {get; set;}
		public string publicKey {get; set;}

		[ForeignKey("bucketId")]
		public virtual Bucket BucketRef { get; set; }
		[ForeignKey("fileTypeId")]
		public virtual FileType FileTypeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e4fac323e50b061bc273d7542efe4d7d</Hash>
</Codenesium>*/