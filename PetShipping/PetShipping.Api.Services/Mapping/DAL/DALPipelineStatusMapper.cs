using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALPipelineStatusMapper : DALAbstractPipelineStatusMapper, IDALPipelineStatusMapper
	{
		public DALPipelineStatusMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4409f28212036c703ccee5bcaf5ea7b6</Hash>
</Codenesium>*/