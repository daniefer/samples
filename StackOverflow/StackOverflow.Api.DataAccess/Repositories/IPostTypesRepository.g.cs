using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IPostTypesRepository
	{
		Task<PostTypes> Create(PostTypes item);

		Task Update(PostTypes item);

		Task Delete(int id);

		Task<PostTypes> Get(int id);

		Task<List<PostTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>33675128cbfb214c575db126a30acba8</Hash>
</Codenesium>*/