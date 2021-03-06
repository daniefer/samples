using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class AccountRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<AccountRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AccountRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Account")]
	[Trait("Area", "Repositories")]
	public partial class AccountRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);

			Account entity = new Account();
			context.Set<Account>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);

			Account entity = new Account();
			context.Set<Account>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);

			var entity = new Account();
			await repository.Create(entity);

			var record = await context.Set<Account>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);
			Account entity = new Account();
			context.Set<Account>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Account>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);
			Account entity = new Account();
			context.Set<Account>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Account());

			var modifiedRecord = context.Set<Account>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<AccountRepository>> loggerMoc = AccountRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AccountRepositoryMoc.GetContext();
			var repository = new AccountRepository(loggerMoc.Object, context);
			Account entity = new Account();
			context.Set<Account>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Account modifiedRecord = await context.Set<Account>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>be23fdc69a6e3d900a0cd79a3db985cd</Hash>
</Codenesium>*/