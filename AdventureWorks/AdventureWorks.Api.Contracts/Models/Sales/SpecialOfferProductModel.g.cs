using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SpecialOfferProductModel
	{
		public SpecialOfferProductModel()
		{}
		public SpecialOfferProductModel(int productID,
		                                Guid rowguid,
		                                DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3fcac1e1286aff604c3c56b5555c6eca</Hash>
</Codenesium>*/