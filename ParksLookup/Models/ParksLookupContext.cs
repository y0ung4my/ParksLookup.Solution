using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
    public class ParksLookupContext : DbContext
    {
        public ParksLookupContext(DbContextOptions<ParksLookupContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Park>().HasData(
                new Park { ParkId = 1, ParkSystem = "National", State = "Wyoming", Name = "Yellowstone", Activities = "hiking, horseback riding, snowshoeing" },
                new Park { ParkId = 2, ParkSystem = "National", State = "Colorado", Name = "Black Canyon of the Gunnison", Activities = "hiking, camping, astronomy" },
                new Park { ParkId = 3, ParkSystem = "State", State = "Colorado", Name = "Staunton State Park", Activities = "hiking, sight-seeing, living history" },
                new Park { ParkId = 4, ParkSystem = "State", State = "Texas", Name = "Huntsville State Park", Activities = "fishing, swimming, kayaking" }
            );
        }

        public DbSet<Park> Parks { get; set; }
    }
}
