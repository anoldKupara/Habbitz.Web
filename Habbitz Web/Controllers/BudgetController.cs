using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BudgetController(ApplicationDbContext dbContext)
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
        public IActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();
                TempData["success"] = "Budget created successfully";
                return RedirectToAction("Index");
            }
            return View(budget);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var budgetFromDb = _dbContext.Budgets.Find(id);
            if (budgetFromDb == null)
            {
                return NotFound();
            }
            return View(budgetFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Budget budget)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Budgets.Update(budget);
                _dbContext.SaveChanges();
                TempData["success"] = "Budget updated successfully";
                return RedirectToAction("Index");
            }
            return View(budget);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var budgetFromDb = _dbContext.Budgets.Find(id);

            if (budgetFromDb == null)
            {
                return NotFound();
            }
            return View(budgetFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBudget(int? id)
        {
            var budgetFromDb = _dbContext.Budgets.Find(id);
            if (budgetFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Budgets.Remove(budgetFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Budget deleted successfully";
            return RedirectToAction("Index");
        }
    }
}