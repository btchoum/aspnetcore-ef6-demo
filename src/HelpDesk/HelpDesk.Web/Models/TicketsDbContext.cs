using HelpDesk.Web.Models.Entities;
using System.Data.Entity;

namespace HelpDesk.Web.Models
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<TicketsDbContext>());
        }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
