using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Buckets.ForEach(x => this.AddBucket(x));
			from.Files.ForEach(x => this.AddFile(x));
			from.FileTypes.ForEach(x => this.AddFileType(x));
			from.VersionInfoes.ForEach(x => this.AddVersionInfo(x));
		}

		public List<ApiBucketResponseModel> Buckets { get; private set; } = new List<ApiBucketResponseModel>();

		public List<ApiFileResponseModel> Files { get; private set; } = new List<ApiFileResponseModel>();

		public List<ApiFileTypeResponseModel> FileTypes { get; private set; } = new List<ApiFileTypeResponseModel>();

		public List<ApiVersionInfoResponseModel> VersionInfoes { get; private set; } = new List<ApiVersionInfoResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeBucketsValue { get; private set; } = true;

		public bool ShouldSerializeBuckets()
		{
			return this.ShouldSerializeBucketsValue;
		}

		public void AddBucket(ApiBucketResponseModel item)
		{
			if (!this.Buckets.Any(x => x.Id == item.Id))
			{
				this.Buckets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFilesValue { get; private set; } = true;

		public bool ShouldSerializeFiles()
		{
			return this.ShouldSerializeFilesValue;
		}

		public void AddFile(ApiFileResponseModel item)
		{
			if (!this.Files.Any(x => x.Id == item.Id))
			{
				this.Files.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFileTypesValue { get; private set; } = true;

		public bool ShouldSerializeFileTypes()
		{
			return this.ShouldSerializeFileTypesValue;
		}

		public void AddFileType(ApiFileTypeResponseModel item)
		{
			if (!this.FileTypes.Any(x => x.Id == item.Id))
			{
				this.FileTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionInfoesValue { get; private set; } = true;

		public bool ShouldSerializeVersionInfoes()
		{
			return this.ShouldSerializeVersionInfoesValue;
		}

		public void AddVersionInfo(ApiVersionInfoResponseModel item)
		{
			if (!this.VersionInfoes.Any(x => x.Version == item.Version))
			{
				this.VersionInfoes.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Buckets.Count == 0)
			{
				this.ShouldSerializeBucketsValue = false;
			}

			if (this.Files.Count == 0)
			{
				this.ShouldSerializeFilesValue = false;
			}

			if (this.FileTypes.Count == 0)
			{
				this.ShouldSerializeFileTypesValue = false;
			}

			if (this.VersionInfoes.Count == 0)
			{
				this.ShouldSerializeVersionInfoesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1d12025254c2753f07cf97f15f596fcc</Hash>
</Codenesium>*/