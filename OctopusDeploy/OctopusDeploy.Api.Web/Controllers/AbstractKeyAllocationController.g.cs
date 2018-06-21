using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractKeyAllocationController : AbstractApiController
        {
                protected IKeyAllocationService KeyAllocationService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractKeyAllocationController(
                        ApiSettings settings,
                        ILogger<AbstractKeyAllocationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IKeyAllocationService keyAllocationService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.KeyAllocationService = keyAllocationService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiKeyAllocationResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiKeyAllocationResponseModel> response = await this.KeyAllocationService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiKeyAllocationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiKeyAllocationResponseModel response = await this.KeyAllocationService.Get(id);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiKeyAllocationResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiKeyAllocationRequestModel model)
                {
                        CreateResponse<ApiKeyAllocationResponseModel> result = await this.KeyAllocationService.Create(model);

                        if (result.Success)
                        {
                                return this.Created ($"{this.Settings.ExternalBaseUrl}/api/KeyAllocations/{result.Record.CollectionName}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiKeyAllocationResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiKeyAllocationRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiKeyAllocationResponseModel> records = new List<ApiKeyAllocationResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiKeyAllocationResponseModel> result = await this.KeyAllocationService.Create(model);

                                if (result.Success)
                                {
                                        records.Add(result.Record);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }

                        return this.Ok(records);
                }

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiKeyAllocationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiKeyAllocationRequestModel model)
                {
                        ActionResponse result = await this.KeyAllocationService.Update(id, model);

                        if (result.Success)
                        {
                                ApiKeyAllocationResponseModel response = await this.KeyAllocationService.Get(id);

                                return this.Ok(response);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.KeyAllocationService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }
        }
}

/*<Codenesium>
    <Hash>aa752dc05c54068ae2ab16938c88355e</Hash>
</Codenesium>*/