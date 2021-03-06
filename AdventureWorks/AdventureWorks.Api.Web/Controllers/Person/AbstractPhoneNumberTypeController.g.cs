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
	public abstract class AbstractPhoneNumberTypeController : AbstractApiController
	{
		protected IPhoneNumberTypeService PhoneNumberTypeService { get; private set; }

		protected IApiPhoneNumberTypeModelMapper PhoneNumberTypeModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPhoneNumberTypeController(
			ApiSettings settings,
			ILogger<AbstractPhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeService phoneNumberTypeService,
			IApiPhoneNumberTypeModelMapper phoneNumberTypeModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PhoneNumberTypeService = phoneNumberTypeService;
			this.PhoneNumberTypeModelMapper = phoneNumberTypeModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPhoneNumberTypeResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPhoneNumberTypeResponseModel> response = await this.PhoneNumberTypeService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPhoneNumberTypeResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPhoneNumberTypeResponseModel response = await this.PhoneNumberTypeService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPhoneNumberTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPhoneNumberTypeRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPhoneNumberTypeResponseModel> records = new List<ApiPhoneNumberTypeResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPhoneNumberTypeResponseModel> result = await this.PhoneNumberTypeService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPhoneNumberTypeResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPhoneNumberTypeRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeResponseModel> result = await this.PhoneNumberTypeService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PhoneNumberTypes/{result.Record.PhoneNumberTypeID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPhoneNumberTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPhoneNumberTypeRequestModel> patch)
		{
			ApiPhoneNumberTypeResponseModel record = await this.PhoneNumberTypeService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPhoneNumberTypeRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPhoneNumberTypeResponseModel> result = await this.PhoneNumberTypeService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPhoneNumberTypeResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPhoneNumberTypeRequestModel model)
		{
			ApiPhoneNumberTypeRequestModel request = await this.PatchModel(id, this.PhoneNumberTypeModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPhoneNumberTypeResponseModel> result = await this.PhoneNumberTypeService.Update(id, request);

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
			ActionResponse result = await this.PhoneNumberTypeService.Delete(id);

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
		[Route("{phoneNumberTypeID}/PersonPhones")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPersonPhoneResponseModel>), 200)]
		public async virtual Task<IActionResult> PersonPhones(int phoneNumberTypeID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPersonPhoneResponseModel> response = await this.PhoneNumberTypeService.PersonPhones(phoneNumberTypeID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPhoneNumberTypeRequestModel> PatchModel(int id, JsonPatchDocument<ApiPhoneNumberTypeRequestModel> patch)
		{
			var record = await this.PhoneNumberTypeService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPhoneNumberTypeRequestModel request = this.PhoneNumberTypeModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>eabf5162b1af43e20543906332c9ca14</Hash>
</Codenesium>*/