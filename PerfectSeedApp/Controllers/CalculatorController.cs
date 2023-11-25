using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        #region Index View

        public IActionResult Index()
        {
            _calculators = _db.Calculator.ToList();

            return View(_calculators);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNextSeed([FromForm] Calculator obj)
        {
            if(obj.Seed != null && _perfectSeedService.IsSeedValid(obj))
            {
                obj.Seed = obj.Seed.ToUpper();
                _db.Calculator.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Calculate(string calculators)
        {
            if (string.IsNullOrEmpty(calculators))
            {
                return RedirectToAction("Index");
            }

            _calculators = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Calculator>>(calculators);
            var x = _perfectSeedService.CalculateBestPossibleSeed(_calculators);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAll(string calculators)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneSeed(string obj)
        {
            var CalculatorObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Calculator>(obj);
            _db.Calculator.Remove(CalculatorObject);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

    }
}
