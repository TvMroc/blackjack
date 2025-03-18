using static test.Blackjack.Deck;

namespace test.Blackjack
{
    static class DealerFunctions
    {
        public static void Shuffle<T>(this IList<T> list, int Shuffles)
        {
            if (list.Count <= 0) return;
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
        public static Card Draw(List<Card> deck)
        {
            Card Card = deck.First();
            deck.Remove(deck.First());
            return Card;
        }
    }
}
