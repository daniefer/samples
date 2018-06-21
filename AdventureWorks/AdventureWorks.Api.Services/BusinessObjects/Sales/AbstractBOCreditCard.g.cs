using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCreditCard : AbstractBusinessObject
        {
                public AbstractBOCreditCard()
                        : base()
                {
                }

                public virtual void SetProperties(int creditCardID,
                                                  string cardNumber,
                                                  string cardType,
                                                  int expMonth,
                                                  short expYear,
                                                  DateTime modifiedDate)
                {
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.CreditCardID = creditCardID;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
                }

                public string CardNumber { get; private set; }

                public string CardType { get; private set; }

                public int CreditCardID { get; private set; }

                public int ExpMonth { get; private set; }

                public short ExpYear { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>19127d4fee9858d27c450f8a44786f5a</Hash>
</Codenesium>*/