using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using PerfectSeedApp.Data;
using PerfectSeedApp.Models;

namespace PerfectSeedApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly DataBaseContext _db;
        private IList<Calculator> _calculators;
        public CalculatorController(DataBaseContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Index()
        {
            _calculators = _db.Calculator.ToList();
            return View(_calculators);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Calculator obj)
        {
            _db.Calculator.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Calculate()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete()
        {
            foreach(var obj in _db.Calculator)
            {
                _db.Calculator.Remove(obj);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
