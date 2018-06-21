using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractEventMapper
        {
                public virtual Event MapBOToEF(
                        BOEvent bo)
                {
                        Event efEvent = new Event();
                        efEvent.SetProperties(
                                bo.Address1,
                                bo.Address2,
                                bo.CityId,
                                bo.Date,
                                bo.Description,
                                bo.EndDate,
                                bo.Facebook,
                                bo.Id,
                                bo.Name,
                                bo.StartDate,
                                bo.Website);
                        return efEvent;
                }

                public virtual BOEvent MapEFToBO(
                        Event ef)
                {
                        var bo = new BOEvent();

                        bo.SetProperties(
                                ef.Id,
                                ef.Address1,
                                ef.Address2,
                                ef.CityId,
                                ef.Date,
                                ef.Description,
                                ef.EndDate,
                                ef.Facebook,
                                ef.Name,
                                ef.StartDate,
                                ef.Website);
                        return bo;
                }

                public virtual List<BOEvent> MapEFToBO(
                        List<Event> records)
                {
                        List<BOEvent> response = new List<BOEvent>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>59a5cba1911b27f206f18409158acf98</Hash>
</Codenesium>*/