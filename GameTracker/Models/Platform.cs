using System.Collections.Generic;

namespace GameTracker.Models
{
  public class Platform
  {
    public Platform()
    {
      this.JoinEntities = new HashSet<GamePlatform>();
      this.MyImage = $"../GameTracker/wwwroot/img/{this.Name}.png";
    }
    public string Name { get; set; }
    public int PlatformId { get; set; }
    public virtual ICollection<GamePlatform> JoinEntities { get; set; }
    public string MyImage { get; set; }
  }
}