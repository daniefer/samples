using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCreditCardModel: AbstractModel
	{
		public ApiCreditCardModel() : base()
		{}

		public ApiCreditCardModel(
			string cardNumber,
			string cardType,
			int expMonth,
			short expYear,
			DateTime modifiedDate)
		{
			this.CardNumber = cardNumber;
			this.CardType = cardType;
			this.ExpMonth = expMonth.ToInt();
			this.ExpYear = expYear;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string cardNumber;

		[Required]
		public string CardNumber
		{
			get
			{
				return this.cardNumber;
			}

			set
			{
				this.cardNumber = value;
			}
		}

		private string cardType;

		[Required]
		public string CardType
		{
			get
			{
				return this.cardType;
			}

			set
			{
				this.cardType = value;
			}
		}

		private int expMonth;

		[Required]
		public int ExpMonth
		{
			get
			{
				return this.expMonth;
			}

			set
			{
				this.expMonth = value;
			}
		}

		private short expYear;

		[Required]
		public short ExpYear
		{
			get
			{
				return this.expYear;
			}

			set
			{
				this.expYear = value;
			}
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
	}
}

/*<Codenesium>
    <Hash>a310140c5706b4fa459d5be4720daa61</Hash>
</Codenesium>*/