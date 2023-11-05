using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSeedApp.Data;

namespace PerfectSeedApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly DataBaseContext _db;
        
        public CalculatorController(DataBaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCalculatorList = _db.Calculator.ToList();
            return View(objCalculatorList);
        }
    }
}
