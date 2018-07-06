using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductSubcategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productSubcategoryID,
                        DateTime modifiedDate,
                        string name,
                        int productCategoryID,
                        Guid rowguid)
                {
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public int ProductSubcategoryID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fc03c423fe3c6ae49360367b2de91ba4</Hash>
</Codenesium>*/