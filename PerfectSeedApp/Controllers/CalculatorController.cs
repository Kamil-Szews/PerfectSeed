using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using PerfectSeedApp.Data;
using PerfectSeedApp.Models;

namespace PerfectSeedApp.Controllers
{
    public class CalculatorController : Controller
    {
        #region Fields and Properties

        private readonly DataBaseContext _db;
        private IList<Calculator> _calculators;

        #endregion

        #region Constructors

        public CalculatorController(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        #region Index

        //GET
        public IActionResult Index()
        {
            _calculators = _db.Calculator.ToList();
            return View(_calculators);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Calculator obj)
        {
            if(obj.Seed != null)
            {
                _db.Calculator.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Calculate

        public IActionResult Calculate()
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAll()
        {
            if(_calculators == null)
            {
                return RedirectToAction("Index");
            }

            foreach(var obj in _calculators)
            {
                _db.Calculator.Remove(obj);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        #endregion
    }
}
