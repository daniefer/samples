using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("WorkerTaskLease", Schema="dbo")]
        public partial class WorkerTaskLease : AbstractEntity
        {
                public WorkerTaskLease()
                {
                }

                public virtual void SetProperties(
                        bool exclusive,
                        string id,
                        string jSON,
                        string name,
                        string taskId,
                        string workerId)
                {
                        this.Exclusive = exclusive;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TaskId = taskId;
                        this.WorkerId = workerId;
                }

                [Column("Exclusive")]
                public bool Exclusive { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("TaskId")]
                public string TaskId { get; private set; }

                [Column("WorkerId")]
                public string WorkerId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0bd33b4fa2d844a5d2fd5fea6c857139</Hash>
</Codenesium>*/