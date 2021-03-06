using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	public abstract class AbstractPostHistoryTypesController : AbstractApiController
	{
		protected IPostHistoryTypesService PostHistoryTypesService { get; private set; }

		protected IApiPostHistoryTypesModelMapper PostHistoryTypesModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPostHistoryTypesController(
			ApiSettings settings,
			ILogger<AbstractPostHistoryTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryTypesService postHistoryTypesService,
			IApiPostHistoryTypesModelMapper postHistoryTypesModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostHistoryTypesService = postHistoryTypesService;
			this.PostHistoryTypesModelMapper = postHistoryTypesModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostHistoryTypesResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPostHistoryTypesResponseModel> response = await this.PostHistoryTypesService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostHistoryTypesResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostHistoryTypesResponseModel response = await this.PostHistoryTypesService.Get(id);

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
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiPostHistoryTypesResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostHistoryTypesRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostHistoryTypesResponseModel> records = new List<ApiPostHistoryTypesResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostHistoryTypesResponseModel> result = await this.PostHistoryTypesService.Create(model);

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

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostHistoryTypesResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPostHistoryTypesRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypesResponseModel> result = await this.PostHistoryTypesService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PostHistoryTypes/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPostHistoryTypesResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostHistoryTypesRequestModel> patch)
		{
			ApiPostHistoryTypesResponseModel record = await this.PostHistoryTypesService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostHistoryTypesRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPostHistoryTypesResponseModel> result = await this.PostHistoryTypesService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPostHistoryTypesResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostHistoryTypesRequestModel model)
		{
			ApiPostHistoryTypesRequestModel request = await this.PatchModel(id, this.PostHistoryTypesModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostHistoryTypesResponseModel> result = await this.PostHistoryTypesService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.PostHistoryTypesService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiPostHistoryTypesRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostHistoryTypesRequestModel> patch)
		{
			var record = await this.PostHistoryTypesService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostHistoryTypesRequestModel request = this.PostHistoryTypesModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b8c4333bfc6dbfb96e1a758c0d573478</Hash>
</Codenesium>*/