using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTaxRateModel: AbstractModel
	{
		public ApiSalesTaxRateModel() : base()
		{}

		public ApiSalesTaxRateModel(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.TaxType = taxType.ToInt();
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private int stateProvinceID;

		[Required]
		public int StateProvinceID
		{
			get
			{
				return this.stateProvinceID;
			}

			set
			{
				this.stateProvinceID = value;
			}
		}

		private decimal taxRate;

		[Required]
		public decimal TaxRate
		{
			get
			{
				return this.taxRate;
			}

			set
			{
				this.taxRate = value;
			}
		}

		private int taxType;

		[Required]
		public int TaxType
		{
			get
			{
				return this.taxType;
			}

			set
			{
				this.taxType = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>782ca009d911d7d7d024a8691b09cbc3</Hash>
</Codenesium>*/