using Habbitz_Web.Data;
using Habbitz_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habbitz_Web.Controllers
{
    public class VaccineController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VaccineController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Vaccine> vaccines = _dbContext.Vaccines;
            return View(vaccines);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Vaccines.Add(vaccine);
                _dbContext.SaveChanges();
                TempData["success"] = "Vaccine created successfully";
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vaccineFromDb = _dbContext.Vaccines.Find(id);
            if (vaccineFromDb == null)
            {
                return NotFound();
            }
            return View(vaccineFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Vaccines.Update(vaccine);
                _dbContext.SaveChanges();
                TempData["success"] = "Vaccine updated successfully";
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vaccineFromDb = _dbContext.Vaccines.Find(id);

            if (vaccineFromDb == null)
            {
                return NotFound();
            }
            return View(vaccineFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVaccine(int? id)
        {
            var vaccineFromDb = _dbContext.Vaccines.Find(id);
            if (vaccineFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Vaccines.Remove(vaccineFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Vaccine deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
