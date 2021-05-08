using Microsoft.EntityFrameworkCore;
using VoteServer.Models;

namespace VoteServer.VoteDatabase
{
    public class VoteDatabase: DbContext
    {
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteToken> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Vote>().Navigation().
        }
    }
}