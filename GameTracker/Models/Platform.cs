using System.Collections.Generic;

namespace GameTracker.Models
{
  public class Platform
  {
    public Platform()
    {
      this.JoinEntities = new HashSet<GamePlatform>();
    }

    public int PlatformId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<GamePlatform> JoinEntities { get; set; }
  }
}