using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models
{
  public class Game
  {
    public Game()
    {
      this.JoinEntities = new HashSet<GamePlatform>();
    }

    public int GameId { get; set; }
    public string Title { get; set; }
    public virtual ApplicationUser User { get; set; }
    public string Genre { get; set; }

    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public string Link { get; set; }
    public virtual ICollection<GamePlatform> JoinEntities { get; }
  }
}