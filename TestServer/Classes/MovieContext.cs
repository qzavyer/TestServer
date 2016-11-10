using System.Data.Entity;
using TestServer.Models;

namespace TestServer.Classes
{
    public class MovieContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MovieContext>(null);
            
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
        }
    }
}