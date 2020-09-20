using HelpDesk.Web.Models;
using HelpDesk.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace HelpDesk.Tests
{
    public class CreateModelTests
    {
        [Test]
        public void OnPost_Works()
        {
            // Arrange
            var page = CreatePageModel();

            // Act
            page.Input = new TicketCreateModel
            {
                Title = "Test Title",
                Details = "Test Details",
                TotalImpactedUsers = 1,
                CreatedBy = "TestUser"
            };
            var result = page.OnPost() as RedirectToPageResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PageName, Is.EqualTo("index").IgnoreCase);
        }

        private static CreateModel CreatePageModel()
        {
            var connectionString = "server=(localdb)\\mssqllocaldb;database=AspnetCoreEf6DemoTests;trusted_connection=true;";
            var context = new TicketsDbContext(connectionString);
            var page = new CreateModel(new TicketCreateHandler(context));
            return page;
        }
    }
}
