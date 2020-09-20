using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Web.Pages
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
    }

    public class TicketCreateHandler
    {
        public void Handle(TicketCreateModel input)
        {
            //TODO: Save ticket to database here ...
            //TODO: Send notification(s)...
        }
    }

}
