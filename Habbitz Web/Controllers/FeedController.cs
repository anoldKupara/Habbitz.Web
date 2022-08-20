using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FeedController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Feed> feeds = _dbContext.Feeds;
            return View(feeds);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feed feed)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Feeds.Add(feed);
                _dbContext.SaveChanges();
                TempData["success"] = "Feed created successfully";
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var feedFromDb = _dbContext.Feeds.Find(id);
            if (feedFromDb == null)
            {
                return NotFound();
            }
            return View(feedFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Feed feed)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Feeds.Update(feed);
                _dbContext.SaveChanges();
                TempData["success"] = "Feed updated successfully";
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var feedFromDb = _dbContext.Feeds.Find(id);

            if (feedFromDb == null)
            {
                return NotFound();
            }
            return View(feedFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFeed(int? id)
        {
            var feed = _dbContext.Feeds.Find(id);
            if (feed == null)
            {
                return NotFound();
            }
            _dbContext.Feeds.Remove(feed);
            _dbContext.SaveChanges();
            TempData["success"] = "Feed deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
