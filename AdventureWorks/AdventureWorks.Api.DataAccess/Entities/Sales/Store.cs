using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Store", Schema="Sales")]
        public partial class Store : AbstractEntity
        {
                public Store()
                {
                }

                public virtual void SetProperties(
                        int businessEntityID,
                        string demographic,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int? salesPersonID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Demographic = demographic;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("Demographics")]
                public string Demographic { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesPersonID")]
                public int? SalesPersonID { get; private set; }

                [ForeignKey("SalesPersonID")]
                public virtual SalesPerson SalesPersonNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>49d1ab334da50529127a8f69bf7b0f76</Hash>
</Codenesium>*/