using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		POCODeviceAction Create(DeviceActionModel model);

		void Update(int id,
		            DeviceActionModel model);

		void Delete(int id);

		POCODeviceAction Get(int id);

		List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>226c7f74e066b84b701c9d80de80ab57</Hash>
</Codenesium>*/