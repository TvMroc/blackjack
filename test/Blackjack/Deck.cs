namespace test.Blackjack
{
    class Deck
    {
        public class Card
        {
            public int[] Value { get; }
            public string Label { get; }
            public Constants.Type Type { get; }

            public Card(int[] value, string label, Constants.Type type)
            {
                Value = value;
                Label = label;
                Type = type;
            }
        }

        public static List<Card> CreateDeck()
        {
            List<Card> Deck = new List<Card>();

            foreach (Constants.Type type in Constants.Types)
            {
                for (int i = 0; i < Constants.DeckLabels.Length; i++)
                {
                    Deck.Add(new Card(Constants.DeckValues[i], Constants.DeckLabels[i], type));
                }
            }

            return Deck;
        }
    }
}
