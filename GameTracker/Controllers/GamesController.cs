using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GameTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GameTracker.Controllers
{
  [Authorize]
  public class GamesController : Controller
  {
    private readonly GameTrackerContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public GamesController(UserManager<ApplicationUser> userManager, GameTrackerContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userGames = _db.Games.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userGames);
    }

    public ActionResult Create()
    {
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Game game, int PlatformId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      game.User = currentUser;
      // Game.GetGames(game.Title);
      _db.Games.Add(game);
      _db.SaveChanges();
      if (PlatformId != 0)
      {
          _db.GamePlatform.Add(new GamePlatform() { PlatformId = PlatformId, GameId = game.GameId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGame = _db.Games
          .Include(game => game.JoinEntities)
          .ThenInclude(join => join.Platform)
          .FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    public ActionResult Edit(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "Name");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game, int PlatformId)
    {
      if (PlatformId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform() { PlatformId = PlatformId, GameId = game.GameId });
      }
      _db.Entry(game).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPlatform(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "Name");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult AddPlatform(Game game, int PlatformId)
    {
      if (PlatformId != 0)
      {
      _db.GamePlatform.Add(new GamePlatform() { PlatformId = PlatformId, GameId = game.GameId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      _db.Games.Remove(thisGame);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeletePlatform(int joinId)
    {
      var joinEntry = _db.GamePlatform.FirstOrDefault(entry => entry.GamePlatformId == joinId);
      _db.GamePlatform.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
