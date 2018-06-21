using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Artifact", Schema="dbo")]
        public partial class Artifact : AbstractEntity
        {
                public Artifact()
                {
                }

                public void SetProperties(
                        DateTimeOffset created,
                        string environmentId,
                        string filename,
                        string id,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Filename = filename;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                }

                [Column("Created")]
                public DateTimeOffset Created { get; private set; }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Column("Filename")]
                public string Filename { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("RelatedDocumentIds")]
                public string RelatedDocumentIds { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>db3e53aa8698bf3826a7981f559370fa</Hash>
</Codenesium>*/