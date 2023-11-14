using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using PerfectSeedApp.Data;
using PerfectSeedApp.Models;
using PerfectSeedApp.Services;

namespace PerfectSeedApp.Controllers
{
    public class CalculatorController : Controller
    {
        #region Fields and Properties

        private readonly PerfectSeedService _perfectSeedService;
        private readonly DataBaseContext _db;
        private IList<Calculator> _calculators;


        #endregion

        #region Constructors

        public CalculatorController(DataBaseContext db, PerfectSeedService perfectSeedService)
        {
            _db = db;
            _perfectSeedService = perfectSeedService;
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
        public IActionResult AddNextSeed([FromForm] Calculator obj)
        {
            if(obj.Seed != null && !_perfectSeedService.IsSeedValid(obj))
            {
                obj.Seed = obj.Seed.ToUpper();
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
        public IActionResult DeleteAll(string calculators)
        {
            if(string.IsNullOrEmpty(calculators))
            {
                return RedirectToAction("Index");
            }

            _calculators = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Calculator>>(calculators);

            foreach (var obj in _calculators)
            {
                _db.Calculator.Remove(obj);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneSeed(string calculators)
        {
            if (string.IsNullOrEmpty(calculators))
            {
                return RedirectToAction("Index");
            }

            _calculators = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Calculator>>(calculators);

            foreach (var obj in _calculators)
            {
                _db.Calculator.Remove(obj);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
