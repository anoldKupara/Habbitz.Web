using Microsoft.AspNetCore.Mvc;
using Habbitz_Web.Models;
using Habbitz_Web.Data;

namespace Habbitz_Web.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentMethodController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<PaymentMethod> paymentMethods = _dbContext.PaymentMethods;
            return View(paymentMethods);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _dbContext.PaymentMethods.Add(paymentMethod);
                _dbContext.SaveChanges();
                TempData["success"] = "PaymentMethod created successfully";
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var paymentMethodFromDb = _dbContext.PaymentMethods.Find(id);
            if (paymentMethodFromDb == null)
            {
                return NotFound();
            }
            return View(paymentMethodFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _dbContext.PaymentMethods.Update(paymentMethod);
                _dbContext.SaveChanges();
                TempData["success"] = "PaymentMethod updated successfully";
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var paymentMethodFromDb = _dbContext.PaymentMethods.Find(id);

            if (paymentMethodFromDb == null)
            {
                return NotFound();
            }
            return View(paymentMethodFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePaymentMethod(int? id)
        {
            var paymentMethodFromDb = _dbContext.PaymentMethods.Find(id);
            if (paymentMethodFromDb == null)
            {
                return NotFound();
            }
            _dbContext.PaymentMethods.Remove(paymentMethodFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "PaymentMethod deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
