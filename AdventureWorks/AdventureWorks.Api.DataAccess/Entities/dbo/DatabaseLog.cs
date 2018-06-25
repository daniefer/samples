using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("DatabaseLog", Schema="dbo")]
        public partial class DatabaseLog : AbstractEntity
        {
                public DatabaseLog()
                {
                }

                public virtual void SetProperties(
                        int databaseLogID,
                        string databaseUser,
                        string @event,
                        string @object,
                        DateTime postTime,
                        string schema,
                        string tSQL,
                        string xmlEvent)
                {
                        this.DatabaseLogID = databaseLogID;
                        this.DatabaseUser = databaseUser;
                        this.@Event = @event;
                        this.@Object = @object;
                        this.PostTime = postTime;
                        this.Schema = schema;
                        this.TSQL = tSQL;
                        this.XmlEvent = xmlEvent;
                }

                [Key]
                [Column("DatabaseLogID")]
                public int DatabaseLogID { get; private set; }

                [Column("DatabaseUser")]
                public string DatabaseUser { get; private set; }

                [Column("Event")]
                public string @Event { get; private set; }

                [Column("Object")]
                public string @Object { get; private set; }

                [Column("PostTime")]
                public DateTime PostTime { get; private set; }

                [Column("Schema")]
                public string Schema { get; private set; }

                [Column("TSQL")]
                public string TSQL { get; private set; }

                [Column("XmlEvent")]
                public string XmlEvent { get; private set; }
        }
}

/*<Codenesium>
    <Hash>07487de8181fc5e18fa0d1a276e1ee4f</Hash>
</Codenesium>*/