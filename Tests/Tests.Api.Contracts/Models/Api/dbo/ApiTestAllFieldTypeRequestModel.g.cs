using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiTestAllFieldTypeRequestModel : AbstractApiRequestModel
	{
		public ApiTestAllFieldTypeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			long fieldBigInt,
			byte[] fieldBinary,
			bool fieldBit,
			string fieldChar,
			DateTime fieldDate,
			DateTime fieldDateTime,
			DateTime fieldDateTime2,
			DateTimeOffset fieldDateTimeOffset,
			decimal fieldDecimal,
			decimal fieldFloat,
			byte[] fieldImage,
			decimal fieldMoney,
			string fieldNChar,
			string fieldNText,
			decimal fieldNumeric,
			string fieldNVarchar,
			decimal fieldReal,
			DateTime fieldSmallDateTime,
			short fieldSmallInt,
			decimal fieldSmallMoney,
			string fieldText,
			TimeSpan fieldTime,
			byte[] fieldTimestamp,
			int fieldTinyInt,
			Guid fieldUniqueIdentifier,
			byte[] fieldVarBinary,
			string fieldVarchar,
			string fieldXML)
		{
			this.FieldBigInt = fieldBigInt;
			this.FieldBinary = fieldBinary;
			this.FieldBit = fieldBit;
			this.FieldChar = fieldChar;
			this.FieldDate = fieldDate;
			this.FieldDateTime = fieldDateTime;
			this.FieldDateTime2 = fieldDateTime2;
			this.FieldDateTimeOffset = fieldDateTimeOffset;
			this.FieldDecimal = fieldDecimal;
			this.FieldFloat = fieldFloat;
			this.FieldImage = fieldImage;
			this.FieldMoney = fieldMoney;
			this.FieldNChar = fieldNChar;
			this.FieldNText = fieldNText;
			this.FieldNumeric = fieldNumeric;
			this.FieldNVarchar = fieldNVarchar;
			this.FieldReal = fieldReal;
			this.FieldSmallDateTime = fieldSmallDateTime;
			this.FieldSmallInt = fieldSmallInt;
			this.FieldSmallMoney = fieldSmallMoney;
			this.FieldText = fieldText;
			this.FieldTime = fieldTime;
			this.FieldTimestamp = fieldTimestamp;
			this.FieldTinyInt = fieldTinyInt;
			this.FieldUniqueIdentifier = fieldUniqueIdentifier;
			this.FieldVarBinary = fieldVarBinary;
			this.FieldVarchar = fieldVarchar;
			this.FieldXML = fieldXML;
		}

		[Required]
		[JsonProperty]
		public long FieldBigInt { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] FieldBinary { get; private set; }

		[Required]
		[JsonProperty]
		public bool FieldBit { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldChar { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime FieldDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime FieldDateTime { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime FieldDateTime2 { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset FieldDateTimeOffset { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldDecimal { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldFloat { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] FieldImage { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldMoney { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldNChar { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldNText { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldNumeric { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldNVarchar { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldReal { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime FieldSmallDateTime { get; private set; }

		[Required]
		[JsonProperty]
		public short FieldSmallInt { get; private set; }

		[Required]
		[JsonProperty]
		public decimal FieldSmallMoney { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldText { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan FieldTime { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] FieldTimestamp { get; private set; }

		[Required]
		[JsonProperty]
		public int FieldTinyInt { get; private set; }

		[Required]
		[JsonProperty]
		public Guid FieldUniqueIdentifier { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] FieldVarBinary { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldVarchar { get; private set; }

		[Required]
		[JsonProperty]
		public string FieldXML { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7aed70f95b0217896197ae2ef18eaa39</Hash>
</Codenesium>*/