using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {

        User player = new Player(500);
        User dealer = new Dealer(500);
        Deck deck = new Deck();


        
        public void StartGame()
        {
            deck.Shuffle(4);
            player.Hit(deck);
            dealer.Hit(deck);
            player.Hit(deck);
            dealer.Hit(deck);

            while (dealer.GetTotal() < 16)
            {
                dealer.Hit(deck);
            }
        }
    }
}
