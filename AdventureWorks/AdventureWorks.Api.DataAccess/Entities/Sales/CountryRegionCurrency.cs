using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CountryRegionCurrency", Schema="Sales")]
        public partial class CountryRegionCurrency: AbstractEntity
        {
                public CountryRegionCurrency()
                {
                }

                public void SetProperties(
                        string countryRegionCode,
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                }

                [Key]
                [Column("CountryRegionCode", TypeName="nvarchar(3)")]
                public string CountryRegionCode { get; private set; }

                [Column("CurrencyCode", TypeName="nchar(3)")]
                public string CurrencyCode { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [ForeignKey("CurrencyCode")]
                public virtual Currency Currency { get; set; }
        }
}

/*<Codenesium>
    <Hash>fbce1afbc386fe82c114210e7dbec5d8</Hash>
</Codenesium>*/