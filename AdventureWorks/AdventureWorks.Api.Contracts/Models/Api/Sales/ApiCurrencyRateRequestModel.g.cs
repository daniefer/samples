using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCurrencyRateRequestModel : AbstractApiRequestModel
        {
                public ApiCurrencyRateRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal averageRate,
                        DateTime currencyRateDate,
                        decimal endOfDayRate,
                        string fromCurrencyCode,
                        DateTime modifiedDate,
                        string toCurrencyCode)
                {
                        this.AverageRate = averageRate;
                        this.CurrencyRateDate = currencyRateDate;
                        this.EndOfDayRate = endOfDayRate;
                        this.FromCurrencyCode = fromCurrencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.ToCurrencyCode = toCurrencyCode;
                }

                private decimal averageRate;

                [Required]
                public decimal AverageRate
                {
                        get
                        {
                                return this.averageRate;
                        }

                        set
                        {
                                this.averageRate = value;
                        }
                }

                private DateTime currencyRateDate;

                [Required]
                public DateTime CurrencyRateDate
                {
                        get
                        {
                                return this.currencyRateDate;
                        }

                        set
                        {
                                this.currencyRateDate = value;
                        }
                }

                private decimal endOfDayRate;

                [Required]
                public decimal EndOfDayRate
                {
                        get
                        {
                                return this.endOfDayRate;
                        }

                        set
                        {
                                this.endOfDayRate = value;
                        }
                }

                private string fromCurrencyCode;

                [Required]
                public string FromCurrencyCode
                {
                        get
                        {
                                return this.fromCurrencyCode;
                        }

                        set
                        {
                                this.fromCurrencyCode = value;
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

                private string toCurrencyCode;

                [Required]
                public string ToCurrencyCode
                {
                        get
                        {
                                return this.toCurrencyCode;
                        }

                        set
                        {
                                this.toCurrencyCode = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3b253daf96663ee0869c52e829981f44</Hash>
</Codenesium>*/