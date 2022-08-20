using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseController(ApplicationDbContext dbContext)
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
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Expenses.Add(expense);
                _dbContext.SaveChanges();
                TempData["success"] = "Expense created successfully";
                return RedirectToAction("Index");
            }
            return View(expense);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expenseFromDb = _dbContext.Expenses.Find(id);
            if (expenseFromDb == null)
            {
                return NotFound();
            }
            return View(expenseFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Expenses.Update(expense);
                _dbContext.SaveChanges();
                TempData["success"] = "Expense updated successfully";
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expenseFromDb = _dbContext.Expenses.Find(id);

            if (expenseFromDb == null)
            {
                return NotFound();
            }
            return View(expenseFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExpense(int? id)
        {
            var expenseFromDb = _dbContext.Expenses.Find(id);
            if (expenseFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Expenses.Remove(expenseFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Expense deleted successfully";
            return RedirectToAction("Index");
        }
    }
}