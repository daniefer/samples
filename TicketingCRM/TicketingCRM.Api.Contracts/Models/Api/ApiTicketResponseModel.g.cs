using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiTicketResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string publicId,
			int ticketStatusId)
		{
			this.Id = id;
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;

			this.TicketStatusIdEntity = nameof(ApiResponse.TicketStatus);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string PublicId { get; private set; }

		[Required]
		[JsonProperty]
		public int TicketStatusId { get; private set; }

		[JsonProperty]
		public string TicketStatusIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>32e65dc9be3f638c9d8c166ceb8892c7</Hash>
</Codenesium>*/