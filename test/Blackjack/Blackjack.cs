using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {

        User player = new Player();
        User dealer = new Dealer();

        public int GetTotal(List<Card> deck)
        {
            int total = deck.Where(x => x.Label != "Ace").Sum(x => x.Value[0]);
            List<Card> Aces = deck.Where(x => x.Label == "Ace").ToList();
            foreach(Card card in Aces)
            {
                total = total + (total + card.Value[0] > 21 ? card.Value[1] : card.Value[0]);
            }
            return total;
        }
        
        public void StartGame()
        {
            Deck deck = new Deck();
            deck.Shuffle(4);
            player.Hit(deck);
            dealer.Hit(deck);
            player.Hit(deck);
            dealer.Hit(deck);

            while (GetTotal(dealer.GetCards()) < 16)
            {
                dealer.Hit(deck);
            }
        }
    }
}
