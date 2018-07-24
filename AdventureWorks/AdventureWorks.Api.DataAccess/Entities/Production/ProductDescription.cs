using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductDescription", Schema="Production")]
        public partial class ProductDescription : AbstractEntity
        {
                public ProductDescription()
                {
                }

                public virtual void SetProperties(
                        string description,
                        DateTime modifiedDate,
                        int productDescriptionID,
                        Guid rowguid)
                {
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.Rowguid = rowguid;
                }

                [Column("Description")]
                public string Description { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("ProductDescriptionID")]
                public int ProductDescriptionID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c8a1b7b64e5edffd7fb884bfb33eae6b</Hash>
</Codenesium>*/