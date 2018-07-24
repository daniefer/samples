using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("City", Schema="dbo")]
        public partial class City : AbstractEntity
        {
                public City()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name,
                        int provinceId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.ProvinceId = provinceId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("provinceId")]
                public int ProvinceId { get; private set; }

                [ForeignKey("ProvinceId")]
                public virtual Province ProvinceNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f9bcb2389f7b2405fbab63919dfeba88</Hash>
</Codenesium>*/