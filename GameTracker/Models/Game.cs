using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

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

    // public static void GetGames(string searchTerm)
    // {
    //   var apiCallTask = ApiHelper.ApiCall(searchTerm);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   List<Game> gameList = JsonConvert.DeserializeObject<List<Game>>(jsonResponse["results"].ToString());

    //   Console.WriteLine(gameList);
    // }
  }
}