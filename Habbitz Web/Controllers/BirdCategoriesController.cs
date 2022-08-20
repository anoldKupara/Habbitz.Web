using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class BirdCategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BirdCategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BirdCategory birdCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.BirdCategories.Add(birdCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "BirdCategory created successfully";
                return RedirectToAction("Index");
            }
            return View(birdCategory);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var birdCategoryFromDb = _dbContext.BirdCategories.Find(id);
            if (birdCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(birdCategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BirdCategory birdCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.BirdCategories.Update(birdCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "BirdCategory updated successfully";
                return RedirectToAction("Index");
            }
            return View(birdCategory);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var birdCategoryFromDb = _dbContext.BirdCategories.Find(id);

            if (birdCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(birdCategoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBirdCategory(int? id)
        {
            var birdCategoryFromDb = _dbContext.BirdCategories.Find(id);
            if (birdCategoryFromDb == null)
            {
                return NotFound();
            }
            _dbContext.BirdCategories.Remove(birdCategoryFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "BirdCategory deleted successfully";
            return RedirectToAction("Index");
        }
    }
}