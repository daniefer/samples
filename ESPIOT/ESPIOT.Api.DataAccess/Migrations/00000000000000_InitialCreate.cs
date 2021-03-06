using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

CREATE TABLE [dbo].[Device](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (90)   NOT NULL,
[publicId] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeviceAction](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[deviceId] [int]     NOT NULL,
[name] [varchar]  (90)   NOT NULL,
[value] [varchar]  (4000)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Device]
ADD CONSTRAINT[PK_Device] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Device] ON[dbo].[Device]
(
[publicId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeviceAction]
ADD CONSTRAINT[PK_Action] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeviceAction_DeviceId] ON[dbo].[DeviceAction]
(
[deviceId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[DeviceAction]  WITH CHECK ADD  CONSTRAINT[FK_DeviceAction_Device] FOREIGN KEY([deviceId])
REFERENCES[dbo].[Device]([id])
GO
ALTER TABLE[dbo].[DeviceAction] CHECK CONSTRAINT[FK_DeviceAction_Device]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}