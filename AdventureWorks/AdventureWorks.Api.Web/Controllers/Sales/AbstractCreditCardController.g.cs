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
	public abstract class AbstractCreditCardController : AbstractApiController
	{
		protected ICreditCardService CreditCardService { get; private set; }

		protected IApiCreditCardModelMapper CreditCardModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractCreditCardController(
			ApiSettings settings,
			ILogger<AbstractCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardService creditCardService,
			IApiCreditCardModelMapper creditCardModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.CreditCardService = creditCardService;
			this.CreditCardModelMapper = creditCardModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCreditCardResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiCreditCardResponseModel> response = await this.CreditCardService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCreditCardResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiCreditCardResponseModel response = await this.CreditCardService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiCreditCardResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCreditCardRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiCreditCardResponseModel> records = new List<ApiCreditCardResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiCreditCardResponseModel> result = await this.CreditCardService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiCreditCardResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiCreditCardRequestModel model)
		{
			CreateResponse<ApiCreditCardResponseModel> result = await this.CreditCardService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/CreditCards/{result.Record.CreditCardID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiCreditCardResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCreditCardRequestModel> patch)
		{
			ApiCreditCardResponseModel record = await this.CreditCardService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiCreditCardRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiCreditCardResponseModel> result = await this.CreditCardService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiCreditCardResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCreditCardRequestModel model)
		{
			ApiCreditCardRequestModel request = await this.PatchModel(id, this.CreditCardModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiCreditCardResponseModel> result = await this.CreditCardService.Update(id, request);

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
			ActionResponse result = await this.CreditCardService.Delete(id);

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
		[Route("byCardNumber/{cardNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiCreditCardResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> ByCardNumber(string cardNumber)
		{
			ApiCreditCardResponseModel response = await this.CreditCardService.ByCardNumber(cardNumber);

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
		[Route("{creditCardID}/PersonCreditCards")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonCreditCardResponseModel>), 200)]
		public async virtual Task<IActionResult> PersonCreditCards(int creditCardID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPersonCreditCardResponseModel> response = await this.CreditCardService.PersonCreditCards(creditCardID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{creditCardID}/SalesOrderHeaders")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> SalesOrderHeaders(int creditCardID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSalesOrderHeaderResponseModel> response = await this.CreditCardService.SalesOrderHeaders(creditCardID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiCreditCardRequestModel> PatchModel(int id, JsonPatchDocument<ApiCreditCardRequestModel> patch)
		{
			var record = await this.CreditCardService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiCreditCardRequestModel request = this.CreditCardModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>da38b2306446d4a16d8f5d315b35b1f5</Hash>
</Codenesium>*/