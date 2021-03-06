using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	public partial class ApplicationDbContext : DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public void SetUserId(Guid userId)
		{
			if (userId == default(Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}

			this.UserId = userId;
		}

		public void SetTenantId(int tenantId)
		{
			if (tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}

			this.TenantId = tenantId;
		}

		public virtual DbSet<Chain> Chains { get; set; }

		public virtual DbSet<ChainStatus> ChainStatus { get; set; }

		public virtual DbSet<Clasp> Clasps { get; set; }

		public virtual DbSet<Link> Links { get; set; }

		public virtual DbSet<LinkLog> LinkLogs { get; set; }

		public virtual DbSet<LinkStatus> LinkStatus { get; set; }

		public virtual DbSet<Machine> Machines { get; set; }

		public virtual DbSet<MachineRefTeam> MachineRefTeams { get; set; }

		public virtual DbSet<Organization> Organizations { get; set; }

		public virtual DbSet<Team> Teams { get; set; }

		public virtual DbSet<VersionInfo> VersionInfoes { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// RowVersion is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect RowVersion columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <returns>int</returns>
		public override int SaveChanges()
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var createdEntry in entries)
				{
					var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWVERSION");
					if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
					{
						entity.CurrentValue = Guid.NewGuid();
					}
				}
			}

			return base.SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Nebula.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appsettings.{environment}.json")
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>2bab24375e97975631f02efce3170818</Hash>
</Codenesium>*/