namespace PerfectSeedApp.Services
{
    public static class GenerateCombinationsService
    {
        private static HashSet<string> combinations = new HashSet<string>();

        public static HashSet<string> GenerateStringCombinations(params char[][] seedCombinations)
        {
            combinations.Clear();
            foreach (var seedCombination in seedCombinations)
            {
                GenerateStringCombinations(seedCombination, 0, seedCombination.Length - 1);
            }
            return combinations;
        }

        private static void GenerateStringCombinations(char[] seedCombination, int start, int end)
        {
            if (start == end)
            {
                combinations.Add(new string(seedCombination));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                Swap(ref seedCombination[start], ref seedCombination[i]);
                GenerateStringCombinations(seedCombination, start + 1, end);
                Swap(ref seedCombination[start], ref seedCombination[i]);
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
