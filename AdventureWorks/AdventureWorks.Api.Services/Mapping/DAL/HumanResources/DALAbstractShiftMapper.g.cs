using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractShiftMapper
	{
		public virtual Shift MapBOToEF(
			BOShift bo)
		{
			Shift efShift = new Shift();
			efShift.SetProperties(
				bo.EndTime,
				bo.ModifiedDate,
				bo.Name,
				bo.ShiftID,
				bo.StartTime);
			return efShift;
		}

		public virtual BOShift MapEFToBO(
			Shift ef)
		{
			var bo = new BOShift();

			bo.SetProperties(
				ef.ShiftID,
				ef.EndTime,
				ef.ModifiedDate,
				ef.Name,
				ef.StartTime);
			return bo;
		}

		public virtual List<BOShift> MapEFToBO(
			List<Shift> records)
		{
			List<BOShift> response = new List<BOShift>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b270b7da0342b735bc87dc84935479c8</Hash>
</Codenesium>*/