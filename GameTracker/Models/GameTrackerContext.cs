using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Models
{
  public class GameTrackerContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Platform> Platforms { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GamePlatform> GamePlatform { get; set; }
    
    public GameTrackerContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}