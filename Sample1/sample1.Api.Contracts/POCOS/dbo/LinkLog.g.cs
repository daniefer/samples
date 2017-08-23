using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample1NS.Api.Contracts
{
	public partial class POCOLinkLog
	{
		public POCOLinkLog()
		{}

		public POCOLinkLog(DateTime dateEntered,
		                   int id,
		                   int linkId,
		                   string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.Log = log;

			LinkId = new ReferenceEntity<int>(linkId,
			                                  "Link");
		}

		public DateTime DateEntered {get; set;}
		public int Id {get; set;}
		public ReferenceEntity<int>LinkId {get; set;}
		public string Log {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeDateEnteredValue {get; set;} = true;

		public bool ShouldSerializeDateEntered()
		{
			return ShouldSerializeDateEnteredValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkIdValue {get; set;} = true;

		public bool ShouldSerializeLinkId()
		{
			return ShouldSerializeLinkIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLogValue {get; set;} = true;

		public bool ShouldSerializeLog()
		{
			return ShouldSerializeLogValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDateEnteredValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLinkIdValue = false;
			this.ShouldSerializeLogValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>263f85eaf97433216f290e2d04b42c05</Hash>
</Codenesium>*/