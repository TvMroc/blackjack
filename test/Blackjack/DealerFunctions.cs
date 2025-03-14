namespace test.Blackjack
{
    static class DealerFunctions
    {
        public static void Shuffle<T>(this IList<T> list, int Shuffles)
        {
            for (; Shuffles > 0; Shuffles--)
            {
                for (int i = list.Count - 1; i > 0; i--)
                {
                    int rnd = Constants.rng.Next(i + 1);
                    T value = list[rnd];
                    list[rnd] = list[i];
                    list[i] = value;
                }
            }
        }
    }
}
