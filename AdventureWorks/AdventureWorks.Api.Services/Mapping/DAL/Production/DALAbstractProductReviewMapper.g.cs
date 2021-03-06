using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductReviewMapper
	{
		public virtual ProductReview MapBOToEF(
			BOProductReview bo)
		{
			ProductReview efProductReview = new ProductReview();
			efProductReview.SetProperties(
				bo.Comment,
				bo.EmailAddress,
				bo.ModifiedDate,
				bo.ProductID,
				bo.ProductReviewID,
				bo.Rating,
				bo.ReviewDate,
				bo.ReviewerName);
			return efProductReview;
		}

		public virtual BOProductReview MapEFToBO(
			ProductReview ef)
		{
			var bo = new BOProductReview();

			bo.SetProperties(
				ef.ProductReviewID,
				ef.Comment,
				ef.EmailAddress,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Rating,
				ef.ReviewDate,
				ef.ReviewerName);
			return bo;
		}

		public virtual List<BOProductReview> MapEFToBO(
			List<ProductReview> records)
		{
			List<BOProductReview> response = new List<BOProductReview>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8edbeef11bc4868c96baed265d7e8d29</Hash>
</Codenesium>*/