using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesPersonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal bonus,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        decimal? salesQuota,
                        decimal salesYTD,
                        int? territoryID)
                {
                        this.Bonus = bonus;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;
                }

                private decimal bonus;

                [Required]
                public decimal Bonus
                {
                        get
                        {
                                return this.bonus;
                        }

                        set
                        {
                                this.bonus = value;
                        }
                }

                private decimal commissionPct;

                [Required]
                public decimal CommissionPct
                {
                        get
                        {
                                return this.commissionPct;
                        }

                        set
                        {
                                this.commissionPct = value;
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

                private decimal salesLastYear;

                [Required]
                public decimal SalesLastYear
                {
                        get
                        {
                                return this.salesLastYear;
                        }

                        set
                        {
                                this.salesLastYear = value;
                        }
                }

                private decimal? salesQuota;

                public decimal? SalesQuota
                {
                        get
                        {
                                return this.salesQuota;
                        }

                        set
                        {
                                this.salesQuota = value;
                        }
                }

                private decimal salesYTD;

                [Required]
                public decimal SalesYTD
                {
                        get
                        {
                                return this.salesYTD;
                        }

                        set
                        {
                                this.salesYTD = value;
                        }
                }

                private int? territoryID;

                public int? TerritoryID
                {
                        get
                        {
                                return this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d1ca17eb06fa5095125eee9aea698f06</Hash>
</Codenesium>*/