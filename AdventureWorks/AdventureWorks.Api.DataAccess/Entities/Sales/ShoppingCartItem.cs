using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ShoppingCartItem", Schema="Sales")]
        public partial class ShoppingCartItem : AbstractEntity
        {
                public ShoppingCartItem()
                {
                }

                public virtual void SetProperties(
                        DateTime dateCreated,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        string shoppingCartID,
                        int shoppingCartItemID)
                {
                        this.DateCreated = dateCreated;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ShoppingCartID = shoppingCartID;
                        this.ShoppingCartItemID = shoppingCartItemID;
                }

                [Column("DateCreated")]
                public DateTime DateCreated { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("Quantity")]
                public int Quantity { get; private set; }

                [Column("ShoppingCartID")]
                public string ShoppingCartID { get; private set; }

                [Key]
                [Column("ShoppingCartItemID")]
                public int ShoppingCartItemID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c453ec989443289db3e51ee9a66de300</Hash>
</Codenesium>*/