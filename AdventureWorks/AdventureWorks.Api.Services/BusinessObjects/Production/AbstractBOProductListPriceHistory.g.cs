using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductListPriceHistory : AbstractBusinessObject
        {
                public AbstractBOProductListPriceHistory()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
                                                  DateTime? endDate,
                                                  decimal listPrice,
                                                  DateTime modifiedDate,
                                                  DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StartDate = startDate;
                }

                public DateTime? EndDate { get; private set; }

                public decimal ListPrice { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9318528bb9878dce7dbf7c17dfb8e48e</Hash>
</Codenesium>*/