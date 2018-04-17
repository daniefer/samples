using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net.Http;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public class ChainFilter: ActionFilterAttribute
	{
		IChainModelValidator validator { get; set; }

		public ChainFilter(IChainModelValidator validator)
		{
			this.validator = validator;
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Result is OkObjectResult)
			{
				OkObjectResult result = context.Result as OkObjectResult;
				if (result.Value is ApiResponse)
				{
					var response = result.Value as ApiResponse;
					response.DisableSerializationOfEmptyFields();
					context.Result = new OkObjectResult(response);
				}
			}
			base.OnActionExecuted(context);
		}

		public override void OnActionExecuting(ActionExecutingContext actionContext)
		{
			if (actionContext.ActionArguments.Any(kv => kv.Value == null))
			{
				actionContext.Result = new BadRequestObjectResult("Null model is invalid");

				return;
			}

			var items = actionContext.ActionArguments.Values.OfType<ChainModel>().ToList();

			if (items.Any())
			{
				if (actionContext.HttpContext.Request.Method == HttpMethod.Post.ToString())
				{
					this.validator.CreateMode();
				}
				else if (actionContext.HttpContext.Request.Method == HttpMethod.Put.ToString())
				{
					this.validator.UpdateMode();
				}
				else if (actionContext.HttpContext.Request.Method == HttpMethod.Delete.ToString())
				{
					this.validator.DeleteMode();
				}
				else
				{
					return;
				}

				Action<ValidationResult> addError = (result) =>
				{
					foreach (var error in result.Errors)
					{
						actionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
				};

				bool validationFailure = false;
				items.ForEach(x =>
				{
					ValidationResult result = this.validator.Validate(x);
					if (!result.IsValid)
					{
					        validationFailure = true;
					        addError(result);
					}
				});

				if (validationFailure)
				{
					actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>9bc35e75acb4dd757973108c9d30b0f4</Hash>
</Codenesium>*/