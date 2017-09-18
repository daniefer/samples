using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace FileServiceNS.Api.Contracts
{
	public partial class BucketModel
	{
		public BucketModel()
		{}

		public BucketModel(Guid externalId,
		                   int id,
		                   string name)
		{
			this.ExternalId = externalId;
			this.Id = id.ToInt();
			this.Name = name;
		}

		public BucketModel(POCOBucket poco)
		{
			this.ExternalId = poco.ExternalId;
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;
		}

		private Guid _externalId;
		public Guid ExternalId
		{
			get
			{
				return _externalId;
			}
			set
			{
				this._externalId = value;
			}
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6f3b360e4dc87666904db57a1a9e62e2</Hash>
</Codenesium>*/