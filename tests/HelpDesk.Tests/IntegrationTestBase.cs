using HelpDesk.Web.Models;
using NUnit.Framework;

namespace HelpDesk.Tests
{
    public class IntegrationTestBase
    {
        [SetUp]
        public void BaseSetup()
        {
            var context = CreateTestTicketsDbContext();
            var deleteAllTestData = "DELETE FROM dbo.Tickets";
            context.Database.ExecuteSqlCommand(deleteAllTestData);
        }

        protected static TicketsDbContext CreateTestTicketsDbContext()
        {
            var connectionString = "server=(localdb)\\mssqllocaldb;database=AspnetCoreEf6DemoTests;trusted_connection=true;";
            var context = new TicketsDbContext(connectionString);
            return context;
        }
    }
}