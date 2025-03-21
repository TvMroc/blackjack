using static test.Blackjack.Deck;
using static test.Blackjack.Dealer;

namespace test.Blackjack
{
    class Blackjack
    {

        private List<Card> PlayerCards = [];
        private List<Card> DealerCards = [];
        public List<Card> GetDealerCards()
        {
            return DealerCards;
        }
        public List<Card> GetPlayerCards()
        {
            return DealerCards;
        }

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
            PlayerCards.Add(deck.Draw());
            DealerCards.Add(deck.Draw());
            PlayerCards.Add(deck.Draw());
            DealerCards.Add(deck.Draw());

            while (GetTotal(DealerCards) < 16)
            {
                DealerCards.Add(deck.Draw());
            }
        }
    }
}
