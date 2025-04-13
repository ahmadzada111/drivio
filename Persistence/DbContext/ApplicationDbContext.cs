using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Announcement> Announcements => Set<Announcement>();
    
    public DbSet<Seller> Sellers => Set<Seller>();
    
    public DbSet<PlatformUser> PlatformUsers => Set<PlatformUser>();
    
    public DbSet<Make> Makes => Set<Make>();
    
    public DbSet<Model> Models => Set<Model>();
}