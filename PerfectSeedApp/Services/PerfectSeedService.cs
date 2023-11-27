using PerfectSeedApp.Models;
using MathNet;
using MathNet.Numerics;
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

        private readonly Dictionary<char, double> seedValue = new Dictionary<char, double>
        {
            { 'X', 0.9 },
            { 'W', 0.9 },
            { 'H', 0.5 },
            { 'Y', 0.5 },
            { 'G', 0.5 }
        };

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

        public bool IsSeedValid(string sequence)
        {
            if (sequence.Length != 6)
                return false;

            bool allValid = sequence.ToUpper().All(x => x == 'H' || x == 'G' || x == 'Y' || x == 'X' || x == 'W');
            return allValid;
        }

        private HashSet<string> SeedsCombinations(IList<Seed> seeds)
        {
            HashSet<string> allCombinations = new HashSet<string>();
            for(int i = 2; i < seeds.Count; i++)
            {

            }

            return new HashSet<string>();
        }

        public string CalculatePerfectSeed(IList<Seed> seeds)
        {
            List<string> currentSeeds = new List<string>();

            for(int i = 2; i < seeds.Count; i++)
            {
                GenerateCombinations(seeds, i, currentSeeds, 0);
                currentSeeds.Clear();
            }
            
            return "xxxxxx";
        }

        static void GenerateCombinations(IList<Seed> seeds, int m, List<string> currentSeeds, int startIndex)
        {
            if (currentSeeds.Count == m)
            {
                ProcessCombination(currentSeeds);
                return;
            }

            for (int i = startIndex; i < seeds.Count; i++)
            {
                if (!currentSeeds.Contains(seeds[i].SeedSequence))
                {
                    currentSeeds.Add(seeds[i].SeedSequence);
                    if (currentSeeds.Count <= m)
                    {
                        GenerateCombinations(seeds, m, currentSeeds, i + 1);
                    }
                    currentSeeds.RemoveAt(currentSeeds.Count - 1);
                }
            }
        }

        static void ProcessCombination(List<string> seeds)
        {
            Dictionary<char, double>[][] seedTable = new Dictionary<char, double>[6][];

            int iterator = 0;
            foreach (var seed in seeds)
            {
                seedTable[iterator] = new Dictionary<char, double>[6];
                for (int i = 0; i < 6; i++)
                {
                    seedTable[iterator][i] = new Dictionary<char, double>();
                    seedTable[iterator][i].Add(seed[i], 1.0);
                }
                iterator++;
            }
        }
    }
}
