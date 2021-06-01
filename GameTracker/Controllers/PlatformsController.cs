using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GameTracker.Models;

namespace GameTracker.Controllers
{
  public class PlatformsController : Controller
  {
    private readonly GameTrackerContext _db;

    public PlatformsController(GameTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Platform> model = _db.Platforms.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Platform platform)
    {
      _db.Platforms.Add(platform);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPlatform = _db.Platforms
          .Include(platform => platform.JoinEntities)
          .ThenInclude(join => join.Game)
          .FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }
    public ActionResult Edit(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }

    [HttpPost]
    public ActionResult Edit(Platform platform)
    {
      _db.Entry(platform).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddGame(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      ViewBag.GameId = new SelectList(_db.Games, "GameId", "Title");
      return View(thisPlatform);
    }

    [HttpPost]
    public ActionResult AddGame(Platform platform, int GameId)
    {
      if (GameId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform(){ GameId = GameId, PlatformId = platform.PlatformId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      _db.Platforms.Remove(thisPlatform);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}