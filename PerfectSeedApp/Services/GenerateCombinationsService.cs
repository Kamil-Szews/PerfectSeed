namespace PerfectSeedApp.Services
{
    public static class GenerateCombinationsService
    {
        static HashSet<string> combinations = new HashSet<string>();

        public static HashSet<string> GenerateStringCombinations(params char[][] seedCombinations)
        {
            foreach(var seedCombination in seedCombinations)
            {
                GenerateStringCombinations(seedCombination, 0, seedCombination.Length - 1);
            }
            return combinations;
        }

        public static void GenerateStringCombinations(char[] seedCombination, int start, int end)
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

        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
