using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractSalesTerritoryController : AbstractApiController
	{
		protected ISalesTerritoryService SalesTerritoryService { get; private set; }

		protected IApiSalesTerritoryModelMapper SalesTerritoryModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSalesTerritoryController(
			ApiSettings settings,
			ILogger<AbstractSalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryService salesTerritoryService,
			IApiSalesTerritoryModelMapper salesTerritoryModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SalesTerritoryService = salesTerritoryService;
			this.SalesTerritoryModelMapper = salesTerritoryModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesTerritoryResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesTerritoryResponseModel> response = await this.SalesTerritoryService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSalesTerritoryResponseModel response = await this.SalesTerritoryService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSalesTerritoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesTerritoryRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSalesTerritoryResponseModel> records = new List<ApiSalesTerritoryResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSalesTerritoryResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSalesTerritoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesTerritories/{result.Record.TerritoryID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTerritoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesTerritoryRequestModel> patch)
		{
			ApiSalesTerritoryResponseModel record = await this.SalesTerritoryService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSalesTerritoryRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSalesTerritoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesTerritoryRequestModel model)
		{
			ApiSalesTerritoryRequestModel request = await this.PatchModel(id, this.SalesTerritoryModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Update(id, request);

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
			ActionResponse result = await this.SalesTerritoryService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByName(string name)
		{
			ApiSalesTerritoryResponseModel response = await this.SalesTerritoryService.ByName(name);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("{territoryID}/Customers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCustomerResponseModel>), 200)]
		public async virtual Task<IActionResult> Customers(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiCustomerResponseModel> response = await this.SalesTerritoryService.Customers(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{territoryID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeaders(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderResponseModel> response = await this.SalesTerritoryService.SalesOrderHeaders(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{territoryID}/SalesPersons")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesPersons(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesPersonResponseModel> response = await this.SalesTerritoryService.SalesPersons(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{territoryID}/SalesTerritoryHistories")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesTerritoryHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesTerritoryHistories(int territoryID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesTerritoryHistoryResponseModel> response = await this.SalesTerritoryService.SalesTerritoryHistories(territoryID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSalesTerritoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesTerritoryRequestModel> patch)
		{
			var record = await this.SalesTerritoryService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSalesTerritoryRequestModel request = this.SalesTerritoryModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>43c3e8f2a020762509b4de775e9c49be</Hash>
</Codenesium>*/