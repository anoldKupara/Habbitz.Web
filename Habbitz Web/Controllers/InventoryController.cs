using Microsoft.AspNetCore.Mvc;
using Habbitz_Web.Models;
using Habbitz_Web.Data;

namespace Habbitz_Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Inventory> inventories = _dbContext.Inventories;
            return View(inventories);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Inventories.Add(inventory);
                _dbContext.SaveChanges();
                TempData["success"] = "Inventory created successfully";
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var inventoryFromDb = _dbContext.Inventories.Find(id);
            if (inventoryFromDb == null)
            {
                return NotFound();
            }
            return View(inventoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Inventories.Update(inventory);
                _dbContext.SaveChanges();
                TempData["success"] = "Inventory updated successfully";
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var inventoryFromDb = _dbContext.Inventories.Find(id);

            if (inventoryFromDb == null)
            {
                return NotFound();
            }
            return View(inventoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInventory(int? id)
        {
            var inventoryFromDb = _dbContext.Inventories.Find(id);
            if (inventoryFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Inventories.Remove(inventoryFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Inventory deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
