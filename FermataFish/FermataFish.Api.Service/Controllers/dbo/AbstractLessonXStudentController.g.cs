using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractLessonXStudentController: AbstractApiController
	{
		protected ILessonXStudentRepository lessonXStudentRepository;

		protected ILessonXStudentModelValidator lessonXStudentModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonXStudentController(
			ILogger<AbstractLessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentRepository lessonXStudentRepository,
			ILessonXStudentModelValidator lessonXStudentModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonXStudentRepository = lessonXStudentRepository;
			this.lessonXStudentModelValidator = lessonXStudentModelValidator;
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
		[LessonXStudentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.lessonXStudentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LessonXStudentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.lessonXStudentRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LessonXStudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LessonXStudentModel model)
		{
			this.lessonXStudentModelValidator.CreateMode();
			var validationResult = this.lessonXStudentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.lessonXStudentRepository.Create(
					model.LessonId,
					model.StudentId);
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
		[LessonXStudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LessonXStudentModel> models)
		{
			this.lessonXStudentModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.lessonXStudentModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.lessonXStudentRepository.Create(
					model.LessonId,
					model.StudentId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LessonXStudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, LessonXStudentModel model)
		{
			if (this.lessonXStudentRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.lessonXStudentModelValidator.UpdateMode();
			var validationResult = this.lessonXStudentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.lessonXStudentRepository.Update(
					id,
					model.LessonId,
					model.StudentId);
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
		[LessonXStudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonXStudentRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonId/{id}")]
		[LessonXStudentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Lessons/{id}/LessonXStudents")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLessonId(int id)
		{
			Response response = this.lessonXStudentRepository.GetWhere(x => x.LessonId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[LessonXStudentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/LessonXStudents")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			Response response = this.lessonXStudentRepository.GetWhere(x => x.StudentId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d07066f72a08aa722fa76728a4ce6c6b</Hash>
</Codenesium>*/