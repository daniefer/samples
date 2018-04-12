using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractSpecialOfferController: AbstractApiController
	{
		protected ISpecialOfferRepository specialOfferRepository;

		protected ISpecialOfferModelValidator specialOfferModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpecialOfferController(
			ILogger<AbstractSpecialOfferController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[SpecialOfferFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.specialOfferRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpecialOfferFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.specialOfferRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SpecialOfferModel model)
		{
			this.specialOfferModelValidator.CreateMode();
			var validationResult = this.specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.specialOfferRepository.Create(
					model.Description,
					model.DiscountPct,
					model.Type,
					model.Category,
					model.StartDate,
					model.EndDate,
					model.MinQty,
					model.MaxQty,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SpecialOfferModel> models)
		{
			this.specialOfferModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.specialOfferModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.specialOfferRepository.Create(
					model.Description,
					model.DiscountPct,
					model.Type,
					model.Category,
					model.StartDate,
					model.EndDate,
					model.MinQty,
					model.MaxQty,
					model.Rowguid,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SpecialOfferModel model)
		{
			if (this.specialOfferRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.specialOfferModelValidator.UpdateMode();
			var validationResult = this.specialOfferModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.specialOfferRepository.Update(
					id,
					model.Description,
					model.DiscountPct,
					model.Type,
					model.Category,
					model.StartDate,
					model.EndDate,
					model.MinQty,
					model.MaxQty,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpecialOfferFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.specialOfferRepository.Delete(id);
			return this.Ok();
		}
	}
}

/*<Codenesium>
    <Hash>cee388d1592a484a36127fc0bacf3ff5</Hash>
</Codenesium>*/