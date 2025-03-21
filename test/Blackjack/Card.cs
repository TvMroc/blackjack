namespace test.Blackjack
{
    class Card
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
}
