using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Password", Schema="Person")]
        public partial class Password : AbstractEntity
        {
                public Password()
                {
                }

                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        string passwordHash,
                        string passwordSalt,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PasswordHash = passwordHash;
                        this.PasswordSalt = passwordSalt;
                        this.Rowguid = rowguid;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PasswordHash")]
                public string PasswordHash { get; private set; }

                [Column("PasswordSalt")]
                public string PasswordSalt { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3933375f89e49cb6130b45f917f124c5</Hash>
</Codenesium>*/