namespace test.Blackjack
{
    class Deck
    {
        public List<Card> Value = new List<Card>();
        public Deck()
        {
            foreach (Constants.Type type in Constants.Types)
            {
                for (int i = 0; i < Constants.DeckLabels.Length; i++)
                {
                    Value.Add(new Card(Constants.DeckValues[i], Constants.DeckLabels[i], type));
                }
            }
        }

        public Card? Draw()
        {
            if (Value.Count <= 0)
            {
                Console.WriteLine("Deck empty");
                return null;
            }
            Card Card = Value.First();
            Value.Remove(Value.First());
            return Card;
        }

        public void Shuffle(int Shuffles)
        {
            if (Value.Count <= 0) return;
            for (; Shuffles > 0; Shuffles--)
            {
                for (int i = Value.Count - 1; i > 0; i--)
                {
                    int rnd = Constants.rng.Next(i + 1);
                    Card value = Value[rnd];
                    Value[rnd] = Value[i];
                    Value[i] = value;
                }
            }
        }
    }
}
