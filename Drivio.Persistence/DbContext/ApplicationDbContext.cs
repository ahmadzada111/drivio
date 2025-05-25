using System.Reflection;
using Drivio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Drivio.Persistence.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Announcement> Announcements { get; set; }
    
    public DbSet<Seller> Sellers { get; set; }
    
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<Make> Makes { get; set; }
    
    public DbSet<Model> Models { get; set; }
}