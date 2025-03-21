using static test.Blackjack.Deck;

namespace test.Blackjack
{
    class Player : User
    {
        public Card? Hit(Deck deck)
        {
            return deck.Draw();
        }
    }
}
