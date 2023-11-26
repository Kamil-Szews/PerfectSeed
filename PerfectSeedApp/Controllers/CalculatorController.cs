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
        private IList<Seed> _seeds;


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
            _seeds = _db.SeedsTable.ToList();
            return View(_seeds);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNextSeed([FromForm] string sequence)
        {
            if (sequence != null && _perfectSeedService.IsSeedValid(sequence))
            {
                Seed seed = new Seed();
                seed.SeedSequence = sequence.ToUpper();
                _db.SeedsTable.Add(seed);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return RedirectToAction("Index");
        }

        public IActionResult Calculate(string seeds)
        {
            if (string.IsNullOrEmpty(seeds))
            {
                return RedirectToAction("Index");
            }

            _seeds = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Seed>>(seeds);
            var x = _perfectSeedService.CalculatePerfectSeed(_seeds);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAll(string seeds)
        {
            if (string.IsNullOrEmpty(seeds))
            {
                return RedirectToAction("Index");
            }

            _seeds = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Seed>>(seeds);

            foreach (var obj in _seeds)
            {
                _db.SeedsTable.Remove(obj);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneSeed(string obj)
        {
            var seed = Newtonsoft.Json.JsonConvert.DeserializeObject<Seed>(obj);
            _db.SeedsTable.Remove(seed);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
