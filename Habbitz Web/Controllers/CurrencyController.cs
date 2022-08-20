using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CurrencyController(ApplicationDbContext dbContext)
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
    public IActionResult Create(Currency currency)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Currencies.Add(currency);
            _dbContext.SaveChanges();
            TempData["success"] = "Currency created successfully";
            return RedirectToAction("Index");
        }
        return View(currency);
    }


    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var currencyFromDb = _dbContext.Currencies.Find(id);
        if (currencyFromDb == null)
        {
            return NotFound();
        }
        return View(currencyFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Currency currency)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Currencies.Update(currency);
            _dbContext.SaveChanges();
            TempData["success"] = "Currency updated successfully";
            return RedirectToAction("Index");
        }
        return View(currency);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var currencyFromDb = _dbContext.Currencies.Find(id);

        if (currencyFromDb == null)
        {
            return NotFound();
        }
        return View(currencyFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCurrency(int? id)
    {
        var currencyFromDb = _dbContext.Currencies.Find(id);
        if (currencyFromDb == null)
        {
            return NotFound();
        }
        _dbContext.Currencies.Remove(currencyFromDb);
        _dbContext.SaveChanges();
        TempData["success"] = "Currency deleted successfully";
        return RedirectToAction("Index");
    }
}
}
