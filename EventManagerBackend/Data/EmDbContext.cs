using EventManagerBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagerBackend.Data
{
    public class EmDbContext : DbContext
    {
        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options)
        {
        }

        public DbSet<EventModel> Events { get; set; }
    }
}
