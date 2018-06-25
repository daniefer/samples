using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCreditCardRequestModel : AbstractApiRequestModel
        {
                public ApiCreditCardRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string cardNumber,
                        string cardType,
                        int expMonth,
                        short expYear,
                        DateTime modifiedDate)
                {
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
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
    <Hash>dce18ece2c9cf47be68e9e7222646f13</Hash>
</Codenesium>*/