using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiSaleRequestModel : AbstractApiRequestModel
        {
                public ApiSaleRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal amount,
                        int clientId,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;
                }

                private decimal amount;

                [Required]
                public decimal Amount
                {
                        get
                        {
                                return this.amount;
                        }

                        set
                        {
                                this.amount = value;
                        }
                }

                private int clientId;

                [Required]
                public int ClientId
                {
                        get
                        {
                                return this.clientId;
                        }

                        set
                        {
                                this.clientId = value;
                        }
                }

                private string note;

                [Required]
                public string Note
                {
                        get
                        {
                                return this.note;
                        }

                        set
                        {
                                this.note = value;
                        }
                }

                private int petId;

                [Required]
                public int PetId
                {
                        get
                        {
                                return this.petId;
                        }

                        set
                        {
                                this.petId = value;
                        }
                }

                private DateTime saleDate;

                [Required]
                public DateTime SaleDate
                {
                        get
                        {
                                return this.saleDate;
                        }

                        set
                        {
                                this.saleDate = value;
                        }
                }

                private int salesPersonId;

                [Required]
                public int SalesPersonId
                {
                        get
                        {
                                return this.salesPersonId;
                        }

                        set
                        {
                                this.salesPersonId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e97b6c7963f882c4821f98faba7cb571</Hash>
</Codenesium>*/