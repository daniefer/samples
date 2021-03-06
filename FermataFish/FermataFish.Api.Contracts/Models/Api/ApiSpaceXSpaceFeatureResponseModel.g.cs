using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceXSpaceFeatureResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;

			this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);
			this.SpaceIdEntity = nameof(ApiResponse.Spaces);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[JsonProperty]
		public string SpaceFeatureIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int SpaceId { get; private set; }

		[JsonProperty]
		public string SpaceIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>0e017c028a724d7f805f03e9df66c6a3</Hash>
</Codenesium>*/