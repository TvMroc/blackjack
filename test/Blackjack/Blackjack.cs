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
