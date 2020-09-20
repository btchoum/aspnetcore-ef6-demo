using HelpDesk.Web.Pages.Tickets;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace HelpDesk.Tests.Tickets
{
    public class CreateModelTests : IntegrationTestBase
    {
        private CreateModel _page;

        [SetUp]
        public void SetUp()
        {
            _page = CreatePageModel();
        }

        [Test]
        public void OnPost_Works()
        {
            // Act
            _page.Input = GivenValidTicketInput();
            var result = _page.OnPost() as RedirectToPageResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PageName, Is.EqualTo("index").IgnoreCase);
        }

        [Test]
        public void OnPost_Works_Again()
        {
            GivenExistingTicket();
        }
        
        private void GivenExistingTicket()
        {
            _page.Input = GivenValidTicketInput();
            _page.OnPost();
        }

        [Test]
        public void OnGet_Works()
        {
            var page = CreatePageModel();

            page.OnGet();
        }

        private static TicketCreateModel GivenValidTicketInput()
        {
            return new TicketCreateModel
            {
                Title = "Test Title",
                Details = "Test Details",
                TotalImpactedUsers = 1,
                CreatedBy = "TestUser"
            };
        }

        private static CreateModel CreatePageModel()
        {
            var context = CreateTestTicketsDbContext();
            var page = new CreateModel(new TicketCreateHandler(context));
            return page;
        }
    }
}
