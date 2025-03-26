using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static test.Blackjack.Deck;

namespace test.Blackjack
{
    class Player : User
    {
        public List<Card> SplitCards { get; private set; } = [];
        private bool AceSplit = false;
        public Player(int money) : base(money)
        {

        }

        public bool CanSplit()
        {
            return Cards.Count == 2 && Cards[0] == Cards[1];
        }

        public void AddCard(Card card, bool splitHit)
        {
            SplitCards.Add(card);
        }

        public void Hit(Deck deck, bool splitHit)
        {
            if (splitHit && !Standing && deck.Value.Count > 0 && !(AceSplit && SplitCards.Count > 1)) AddCard(deck.Draw(), true);
            if (!splitHit && !Standing && deck.Value.Count > 0 && !(AceSplit && Cards.Count > 1)) AddCard(deck.Draw());

        }

        public void DoubleDown(Deck deck)
        {
            if (GetTotal() > Constants.doubleDownRange[0] && GetTotal() < Constants.doubleDownRange[1] && Bet * 2 <= Money)
            {
                SetBet(Bet * 2);
                Hit(deck);
                Stand();
                return;
            }
            Console.WriteLine("Not enough money");
        }

        public void Split()
        {
            if (CanSplit())
            {
                AddCard(Cards[0], true);
                if (Cards[0].Label == "Ace") AceSplit = true;
                SetCards([Cards[0]]);
            }
        }

        public void Surrender()
        {
            SetBet(Bet / 2);
            Stand();
        }
    }
}
