using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCurrency : AbstractBusinessObject
        {
                public AbstractBOCurrency()
                        : base()
                {
                }

                public virtual void SetProperties(string currencyCode,
                                                  DateTime modifiedDate,
                                                  string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CurrencyCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b481e0332269b446c341492e2d23af4e</Hash>
</Codenesium>*/