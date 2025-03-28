namespace test.Blackjack
{
    class Card
    {
        public int[] Value { get; private set; }
        public string Label { get; private set; }
        public Constants.Type Type { get; private set; }
        public Card(int[] value, string label, Constants.Type type)
        {
            Value = value;
            Label = label;
            Type = type;
        }
    }
}
