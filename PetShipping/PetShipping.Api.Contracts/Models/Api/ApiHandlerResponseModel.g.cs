using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiHandlerResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Email { get; private set; }

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4a381d3c7dfa4df53b06089b2b2656cd</Hash>
</Codenesium>*/