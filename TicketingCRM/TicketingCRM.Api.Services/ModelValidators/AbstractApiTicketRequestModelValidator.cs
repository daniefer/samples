using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTicketRequestModelValidator : AbstractValidator<ApiTicketRequestModel>
	{
		private int existingRecordId;

		private ITicketRepository ticketRepository;

		public AbstractApiTicketRequestModelValidator(ITicketRepository ticketRepository)
		{
			this.ticketRepository = ticketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).Length(0, 8);
		}

		public virtual void TicketStatusIdRules()
		{
			this.RuleFor(x => x.TicketStatusId).MustAsync(this.BeValidTicketStatus).When(x => x?.TicketStatusId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTicketStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ticketRepository.GetTicketStatus(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d41b48319807d28b42c8dd4e0b7d1442</Hash>
</Codenesium>*/