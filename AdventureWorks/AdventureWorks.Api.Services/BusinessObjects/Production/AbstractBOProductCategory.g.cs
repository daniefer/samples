using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductCategory : AbstractBusinessObject
	{
		public AbstractBOProductCategory()
			: base()
		{
		}

		public virtual void SetProperties(int productCategoryID,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductCategoryID = productCategoryID;
			this.Rowguid = rowguid;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public int ProductCategoryID { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e6874583f4e278821aef75fefc613c82</Hash>
</Codenesium>*/