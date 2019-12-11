using BetService.Repository.Entity;
using System.Data.Entity;

namespace BetService.Repository
{
    public class BetDbContext : DbContext
    {
        public BetDbContext() : base("myconnection")
        {
        }

        public DbSet<Players> Players { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Bets> Bets { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
