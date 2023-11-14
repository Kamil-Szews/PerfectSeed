using PerfectSeedApp.Models;

namespace PerfectSeedApp.Services
{
    public class PerfectSeedService
    {
        public bool IsSeedValid(Calculator calculator)
        {
            calculator.Seed.ToUpper();
            bool allValid = calculator.Seed.All(x => x == 'H' || x == 'G' || x == 'Y' || x == 'X' || x == 'W');
            return allValid;
        }
    }
}
