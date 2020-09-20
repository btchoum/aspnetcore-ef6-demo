using System;

namespace HelpDesk.Web.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int TotalImpactedUsers { get; set; }

        public Ticket()
        {
            Created = DateTime.UtcNow;
        }
    }


}
