using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractActionTemplateMapper
        {
                public virtual BOActionTemplate MapModelToBO(
                        string id,
                        ApiActionTemplateRequestModel model
                        )
                {
                        BOActionTemplate boActionTemplate = new BOActionTemplate();
                        boActionTemplate.SetProperties(
                                id,
                                model.ActionType,
                                model.CommunityActionTemplateId,
                                model.JSON,
                                model.Name,
                                model.Version);
                        return boActionTemplate;
                }

                public virtual ApiActionTemplateResponseModel MapBOToModel(
                        BOActionTemplate boActionTemplate)
                {
                        var model = new ApiActionTemplateResponseModel();

                        model.SetProperties(boActionTemplate.Id, boActionTemplate.ActionType, boActionTemplate.CommunityActionTemplateId, boActionTemplate.JSON, boActionTemplate.Name, boActionTemplate.Version);

                        return model;
                }

                public virtual List<ApiActionTemplateResponseModel> MapBOToModel(
                        List<BOActionTemplate> items)
                {
                        List<ApiActionTemplateResponseModel> response = new List<ApiActionTemplateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a4b193fd1a945fec89162b96e1808deb</Hash>
</Codenesium>*/