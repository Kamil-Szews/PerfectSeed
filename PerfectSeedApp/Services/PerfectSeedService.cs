using PerfectSeedApp.Models;
using System.Collections;
using System.Diagnostics;

namespace PerfectSeedApp.Services
{
    public class PerfectSeedService
    {
        private readonly HashSet<string> perfectSeeds = GenerateCombinationsService.GenerateStringCombinations(
            new char[] { 'G', 'G', 'G', 'Y', 'Y', 'Y' },
            new char[] { 'G', 'G', 'G', 'G', 'Y', 'Y' },
            new char[] { 'G', 'G', 'Y', 'Y', 'Y', 'Y' }
            );

        private bool IsPerfect(string seed)
        {
            foreach(var perfectSeed in perfectSeeds)
            {
                if (seed == perfectSeed)
                    return true;
            }
            return false;
        }

        public bool IsSeedValid(Seed seed)
        {
            if(seed.SeedSequence.Length != 6) 
                return false;

            bool allValid = seed.SeedSequence.ToUpper().All(x => x == 'H' || x == 'G' || x == 'Y' || x == 'X' || x == 'W');
            return allValid;
        }

        public string CalculatePerfectSeed(IList<Seed> seeds)
        {
            foreach(Seed seed in seeds)
            {
                
            }
            bool x = IsPerfect("GYGYYY");
            return "xxxxxx";
        }
    }
}
