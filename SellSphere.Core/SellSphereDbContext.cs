using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace SellSphere.Core
{
    public class SellSphereDbContext : IdentityDbContext<User>
    {
        public SellSphereDbContext(DbContextOptions<SellSphereDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public DbSet<Goods> Goodes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Contacts> Contactses { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Location> Locations { get; set; }
        

    }
}