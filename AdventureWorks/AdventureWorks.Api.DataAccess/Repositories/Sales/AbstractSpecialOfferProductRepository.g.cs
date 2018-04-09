using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractSpecialOfferProductRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSpecialOfferProductRepository(ILogger logger,
		                                             ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int productID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSpecialOfferProduct ();

			MapPOCOToEF(0, productID,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFSpecialOfferProduct>().Add(record);
			this.context.SaveChanges();
			return record.SpecialOfferID;
		}

		public virtual void Update(int specialOfferID, int productID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",specialOfferID);
			}
			else
			{
				MapPOCOToEF(specialOfferID,  productID,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSpecialOfferProduct>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int specialOfferID, Response response)
		{
			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEF(Expression<Func<EFSpecialOfferProduct, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpecialOfferProducts;
		}
		public virtual POCOSpecialOfferProduct GetByIdDirect(int specialOfferID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID,response);
			return response.SpecialOfferProducts.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFSpecialOfferProduct, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int specialOfferID, int productID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSpecialOfferProduct   efSpecialOfferProduct)
		{
			efSpecialOfferProduct.SpecialOfferID = specialOfferID;
			efSpecialOfferProduct.ProductID = productID;
			efSpecialOfferProduct.Rowguid = rowguid;
			efSpecialOfferProduct.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSpecialOfferProduct efSpecialOfferProduct,Response response)
		{
			if(efSpecialOfferProduct == null)
			{
				return;
			}
			response.AddSpecialOfferProduct(new POCOSpecialOfferProduct()
			{
				Rowguid = efSpecialOfferProduct.Rowguid,
				ModifiedDate = efSpecialOfferProduct.ModifiedDate.ToDateTime(),

				SpecialOfferID = new ReferenceEntity<int>(efSpecialOfferProduct.SpecialOfferID,
				                                          "SpecialOffers"),
				ProductID = new ReferenceEntity<int>(efSpecialOfferProduct.ProductID,
				                                     "Products"),
			});

			SpecialOfferRepository.MapEFToPOCO(efSpecialOfferProduct.SpecialOffer, response);

			ProductRepository.MapEFToPOCO(efSpecialOfferProduct.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>8e8dcc965d34fd3270d372dca75b27a9</Hash>
</Codenesium>*/