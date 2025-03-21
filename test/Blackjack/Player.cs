using static test.Blackjack.Deck;

namespace test.Blackjack
{
    class Player
    {
        public Card? Hit(Deck deck)
        {
            return deck.Draw();
        }
    }
}
