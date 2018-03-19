using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public abstract class AbstractLinkLogModelValidator: AbstractValidator<LinkLogModel>
	{
		public new ValidationResult Validate(LinkLogModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LinkLogModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILinkRepository LinkRepository {get; set;}

		public virtual void DateEnteredRules()
		{
			RuleFor(x => x.DateEntered).NotNull();
		}

		public virtual void LinkIdRules()
		{
			RuleFor(x => x.LinkId).NotNull();
			RuleFor(x => x.LinkId).Must(BeValidLink).When(x => x ?.LinkId != null).WithMessage("Invalid reference");
		}

		public virtual void LogRules()
		{
			RuleFor(x => x.Log).NotNull();
			RuleFor(x => x.Log).Length(0,2147483647);
		}

		public bool BeValidLink(int id)
		{
			Response response = new Response();

			this.LinkRepository.GetById(id,response);
			return response.Links.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>fb5a008f1f72d17f1ab060545177ee15</Hash>
</Codenesium>*/