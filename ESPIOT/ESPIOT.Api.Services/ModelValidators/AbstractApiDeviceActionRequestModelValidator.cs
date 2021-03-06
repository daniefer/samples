using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceActionRequestModelValidator : AbstractValidator<ApiDeviceActionRequestModel>
	{
		private int existingRecordId;

		private IDeviceActionRepository deviceActionRepository;

		public AbstractApiDeviceActionRequestModelValidator(IDeviceActionRepository deviceActionRepository)
		{
			this.deviceActionRepository = deviceActionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDevice).When(x => x?.DeviceId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void @ValueRules()
		{
			this.RuleFor(x => x.@Value).Length(0, 4000);
		}

		private async Task<bool> BeValidDevice(int id,  CancellationToken cancellationToken)
		{
			var record = await this.deviceActionRepository.GetDevice(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>257eae8f639705da13df66dd2ee58970</Hash>
</Codenesium>*/