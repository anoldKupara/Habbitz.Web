using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Sale> sales = _dbContext.Sales;
            return View(sales);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Sales.Add(sale);
                _dbContext.SaveChanges();
                TempData["success"] = "Sale created successfully";
                return RedirectToAction("Index");
            }
            return View(sale);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var saleFromDb = _dbContext.Sales.Find(id);
            if (saleFromDb == null)
            {
                return NotFound();
            }
            return View(saleFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Sales.Update(sale);
                _dbContext.SaveChanges();
                TempData["success"] = "Sale updated successfully";
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var saleFromDb = _dbContext.Sales.Find(id);

            if (saleFromDb == null)
            {
                return NotFound();
            }
            return View(saleFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSale(int? id)
        {
            var saleFromDb = _dbContext.Sales.Find(id);
            if (saleFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Sales.Remove(saleFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Sale deleted successfully";
            return RedirectToAction("Index");
        }
    }
}