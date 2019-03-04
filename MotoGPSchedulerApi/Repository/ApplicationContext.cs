using Microsoft.EntityFrameworkCore;
using MotoGPSchedulerApi.Models;

namespace MotoGPSchedulerApi.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Record>().ToTable("Record");
            modelBuilder.Entity<Circuit>().ToTable("Circuit");
            modelBuilder.Entity<Event>().ToTable("Event");
        }
    }
}
