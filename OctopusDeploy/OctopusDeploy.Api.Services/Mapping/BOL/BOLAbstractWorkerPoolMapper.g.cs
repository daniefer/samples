using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractWorkerPoolMapper
        {
                public virtual BOWorkerPool MapModelToBO(
                        string id,
                        ApiWorkerPoolRequestModel model
                        )
                {
                        BOWorkerPool boWorkerPool = new BOWorkerPool();
                        boWorkerPool.SetProperties(
                                id,
                                model.IsDefault,
                                model.JSON,
                                model.Name,
                                model.SortOrder);
                        return boWorkerPool;
                }

                public virtual ApiWorkerPoolResponseModel MapBOToModel(
                        BOWorkerPool boWorkerPool)
                {
                        var model = new ApiWorkerPoolResponseModel();

                        model.SetProperties(boWorkerPool.Id, boWorkerPool.IsDefault, boWorkerPool.JSON, boWorkerPool.Name, boWorkerPool.SortOrder);

                        return model;
                }

                public virtual List<ApiWorkerPoolResponseModel> MapBOToModel(
                        List<BOWorkerPool> items)
                {
                        List<ApiWorkerPoolResponseModel> response = new List<ApiWorkerPoolResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>37776f41b338cf2b90eb2adbc4f6e740</Hash>
</Codenesium>*/