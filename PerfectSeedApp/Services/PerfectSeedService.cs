using PerfectSeedApp.Models;
using MathNet;
using MathNet.Numerics;
using System.Collections;
using System.Diagnostics;

namespace PerfectSeedApp.Services
{
    public class PerfectSeedService
    {
        private static readonly HashSet<string> perfectSeeds = GenerateCombinationsService.GenerateStringCombinations(
            new char[] { 'G', 'G', 'G', 'Y', 'Y', 'Y' },
            new char[] { 'G', 'G', 'G', 'G', 'Y', 'Y' },
            new char[] { 'G', 'G', 'Y', 'Y', 'Y', 'Y' }
            );

        private static readonly Dictionary<char, double> seedValue = new Dictionary<char, double>
        {
            { 'X', 0.9 },
            { 'W', 0.9 },
            { 'H', 0.5 },
            { 'Y', 0.5 },
            { 'G', 0.5 }
        };

        private static bool IsPerfect(string seed)
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
            HashSet<string> allCombinations = new HashSet<string>();

            for(int combinationLength = 2; combinationLength < seeds.Count; combinationLength++)
            {
                GenerateCombinations(seeds, combinationLength, currentSeeds);
                currentSeeds.Clear();
            }
            
            return "xxxxxx";
        }

        static void GenerateCombinations(IList<Seed> seeds, int combinationLength, List<string> currentSeeds, int startIndex = 0)
        {
            if (currentSeeds.Count == combinationLength)
            {
                ProcessCombination(currentSeeds);
                return;
            }

            for (int i = startIndex; i < seeds.Count; i++)
            {
                if (!currentSeeds.Contains(seeds[i].SeedSequence))
                {
                    currentSeeds.Add(seeds[i].SeedSequence);
                    if (currentSeeds.Count <= combinationLength)
                    {
                        GenerateCombinations(seeds, combinationLength, currentSeeds, i + 1);
                    }
                    currentSeeds.RemoveAt(currentSeeds.Count - 1);
                }
            }
        }

        static void ProcessCombination(List<string> seeds)
        {
            // tab size: 6 x 5, every row is for different gene, Gene order: G Y H W X
            double[][] tab = new double[6][];
            char[] result = new char[6];
            foreach(var seed in seeds)
            {
                for (int j = 0; j < 6; j++)
                {
                    switch(seed[j])
                    {
                        case 'G':
                            tab[j][0] += seedValue['G'];
                            break;

                        case 'Y':
                            tab[j][1] += seedValue['Y'];
                            break;

                        case 'H':
                            tab[j][2] += seedValue['H'];
                            break;

                        case 'W':
                            tab[j][3] += seedValue['W'];
                            break;

                        case 'X':
                            tab[j][4] += seedValue['X'];
                            break;
                    }
                }
            }
            for(int i = 0; i < 6; i++)
            {
               // result[i] = tab[i].Where(row => row == ;
            }

            if (IsPerfect(result.ToString()))
            {

            }
        }
    }
}
