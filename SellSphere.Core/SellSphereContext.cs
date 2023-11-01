using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;

namespace SellSphere.Core;

public class SellSphereContext : IdentityDbContext<User>
{
    public SellSphereContext(DbContextOptions<SellSphereContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Seed();
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Goods> Goodes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Condition> Conditions { get; set; }

    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Location> Locations { get; set; }
}
