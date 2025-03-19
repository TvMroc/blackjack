using static test.Blackjack.Deck;

namespace test.Blackjack
{
    class PlayerFunctions
    {
        public Card Hit(List<Card> deck)
        {
            return DealerFunctions.Draw(deck);
        }
    }
}
