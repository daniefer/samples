using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractEmployeeMapper
	{
		public virtual Employee MapBOToEF(
			BOEmployee bo)
		{
			Employee efEmployee = new Employee();
			efEmployee.SetProperties(
				bo.FirstName,
				bo.Id,
				bo.IsSalesPerson,
				bo.IsShipper,
				bo.LastName);
			return efEmployee;
		}

		public virtual BOEmployee MapEFToBO(
			Employee ef)
		{
			var bo = new BOEmployee();

			bo.SetProperties(
				ef.Id,
				ef.FirstName,
				ef.IsSalesPerson,
				ef.IsShipper,
				ef.LastName);
			return bo;
		}

		public virtual List<BOEmployee> MapEFToBO(
			List<Employee> records)
		{
			List<BOEmployee> response = new List<BOEmployee>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>54e14cbfe3bb68234208dcd1a1f7d845</Hash>
</Codenesium>*/