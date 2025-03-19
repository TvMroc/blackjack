using static test.Blackjack.Deck;
using static test.Blackjack.DealerFunctions;

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

        public int CountAces(List<Card> deck)
        {
            return deck.Where(x => x.Label == "Ace").Count();
        }
        public int GetTotal(List<Card> deck)
        {
            int aceCount = CountAces(deck);
            int switchedAces = 0;
            int total = 0;
            foreach(Card card in deck)
            {
                total = total+card.Value[0];
            }
            while (total > 21)
            {
                if (total > 21 && switchedAces < aceCount)
                {
                    total = total-10;
                    switchedAces++;
                } else
                {
                    break;
                }
            }

            return total;
        }
            
        public void StartGame()
        {
            List<Card> Deck = CreateDeck();
            Deck.Shuffle(4);
            PlayerCards.Add(Draw(Deck));
            DealerCards.Add(Draw(Deck));
            PlayerCards.Add(Draw(Deck));
            DealerCards.Add(Draw(Deck));

            while (GetTotal(DealerCards) < 17)
            {
                DealerCards.Add(Draw(Deck));
            }
        }
    }
}
