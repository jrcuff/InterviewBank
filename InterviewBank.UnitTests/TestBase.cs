using InterviewBank.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InterviewBank.UnitTests
{
    public class TestBase
    {
        public BankDbContext Context { get; }

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<BankDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString(), new InMemoryDatabaseRoot())
                .EnableSensitiveDataLogging()
                .Options;

            Context = new BankDbContext(options);
            Context.Database.EnsureCreated();
        }
    }
}
