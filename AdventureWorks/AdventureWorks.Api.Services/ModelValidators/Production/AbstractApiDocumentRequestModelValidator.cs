using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDocumentRequestModelValidator : AbstractValidator<ApiDocumentRequestModel>
	{
		private Guid existingRecordId;

		private IDocumentRepository documentRepository;

		public AbstractApiDocumentRequestModelValidator(IDocumentRepository documentRepository)
		{
			this.documentRepository = documentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDocumentRequestModel model, Guid id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChangeNumberRules()
		{
		}

		public virtual void Document1Rules()
		{
		}

		public virtual void DocumentLevelRules()
		{
		}

		public virtual void DocumentSummaryRules()
		{
		}

		public virtual void FileExtensionRules()
		{
			this.RuleFor(x => x.FileExtension).NotNull();
			this.RuleFor(x => x.FileExtension).Length(0, 8);
		}

		public virtual void FileNameRules()
		{
			this.RuleFor(x => x.FileName).NotNull();
			this.RuleFor(x => x.FileName).Length(0, 400);
		}

		public virtual void FolderFlagRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OwnerRules()
		{
		}

		public virtual void RevisionRules()
		{
			this.RuleFor(x => x.Revision).NotNull();
			this.RuleFor(x => x.Revision).Length(0, 5);
		}

		public virtual void StatusRules()
		{
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).NotNull();
			this.RuleFor(x => x.Title).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>97e49e66bfded4a5c9460ebaee8e547c</Hash>
</Codenesium>*/