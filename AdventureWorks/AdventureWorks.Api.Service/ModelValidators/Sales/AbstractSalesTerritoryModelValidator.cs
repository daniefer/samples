using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesTerritoryModelValidator: AbstractValidator<SalesTerritoryModel>
	{
		public new ValidationResult Validate(SalesTerritoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesTerritoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRegionRepository CountryRegionRepository {get; set;}
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void CountryRegionCodeRules()
		{
			RuleFor(x => x.CountryRegionCode).NotNull();
			RuleFor(x => x.CountryRegionCode).Must(BeValidCountryRegion).When(x => x ?.CountryRegionCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.CountryRegionCode).Length(0,3);
		}

		public virtual void @GroupRules()
		{
			RuleFor(x => x.@Group).NotNull();
			RuleFor(x => x.@Group).Length(0,50);
		}

		public virtual void SalesYTDRules()
		{
			RuleFor(x => x.SalesYTD).NotNull();
		}

		public virtual void SalesLastYearRules()
		{
			RuleFor(x => x.SalesLastYear).NotNull();
		}

		public virtual void CostYTDRules()
		{
			RuleFor(x => x.CostYTD).NotNull();
		}

		public virtual void CostLastYearRules()
		{
			RuleFor(x => x.CostLastYear).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidCountryRegion(string id)
		{
			Response response = new Response();

			this.CountryRegionRepository.GetById(id,response);
			return response.CountryRegions.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>3fd5a6fc3c05a4a180533a0a6cb18d29</Hash>
</Codenesium>*/