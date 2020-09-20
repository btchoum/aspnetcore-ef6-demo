using HelpDesk.Web.Models;
using HelpDesk.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Web.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly TicketCreateHandler _handler;

        public CreateModel(TicketCreateHandler handler)
        {
            _handler = handler;
        }

        [BindProperty]
        public TicketCreateModel Input { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _handler.Handle(Input);

            return RedirectToPage("Index");
        }
    }

    public class TicketCreateModel
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int TotalImpactedUsers { get; set; }
        public string CreatedBy { get; set; }
    }

    public class TicketCreateHandler
    {
        private readonly TicketsDbContext _context;

        public TicketCreateHandler(TicketsDbContext context)
        {
            _context = context;
        }

        public void Handle(TicketCreateModel input)
        {
            // Create the ticket
            var ticket = new Ticket
            {
                Title = input.Title,
                Details = input.Details,
                TotalImpactedUsers = input.TotalImpactedUsers,
                CreatedBy = input.CreatedBy
            };

            // Save ticket to database here ...
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            //TODO: Send notification(s)...
        }
    }

}
