using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiAdminRequestModel: AbstractApiRequestModel
	{
		public ApiAdminRequestModel() : base()
		{}

		public void SetProperties(
			Nullable<DateTime> birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int studioId)
		{
			this.Birthday = birthday.ToNullableDateTime();
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.StudioId = studioId.ToInt();
		}

		private Nullable<DateTime> birthday;

		public Nullable<DateTime> Birthday
		{
			get
			{
				return this.birthday.IsEmptyOrZeroOrNull() ? null : this.birthday;
			}

			set
			{
				this.birthday = value;
			}
		}

		private string email;

		[Required]
		public string Email
		{
			get
			{
				return this.email;
			}

			set
			{
				this.email = value;
			}
		}

		private string firstName;

		[Required]
		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				this.firstName = value;
			}
		}

		private string lastName;

		[Required]
		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				this.lastName = value;
			}
		}

		private string phone;

		[Required]
		public string Phone
		{
			get
			{
				return this.phone;
			}

			set
			{
				this.phone = value;
			}
		}

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9811214a25de2d8dc1098d96b99e2231</Hash>
</Codenesium>*/