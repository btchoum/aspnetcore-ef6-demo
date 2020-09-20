using HelpDesk.Web.Models;
using NUnit.Framework;

namespace HelpDesk.Tests
{
    public class IntegrationTestBase
    {
        [SetUp]
        public void BaseSetup()
        {
            DeleteAllTestData();
        }

        protected static TicketsDbContext CreateTestTicketsDbContext()
        {
            var connectionString = "server=(localdb)\\mssqllocaldb;database=AspnetCoreEf6DemoTests;trusted_connection=true;";
            var context = new TicketsDbContext(connectionString);
            return context;
        }

        private static void DeleteAllTestData()
        {
            var context = CreateTestTicketsDbContext();

            var sqlStatements = new[]
            {
                "DELETE FROM dbo.Tickets",
                "DBCC CHECKIDENT ('Tickets', RESEED, 0)"
            };

            foreach (var sql in sqlStatements)
            {
                context.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}