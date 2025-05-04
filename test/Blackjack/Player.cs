using static test.Blackjack.Constants;

namespace test.Blackjack
{
    class Player : User
    {
        public List<Card> SplitHand { get; private set; } = [];
        private bool AceSplit = false;
        public bool HasSplit { get; private set; } = false;
        public Player(int money) : base(money)
        {
        }

        public int GetTotal(bool splitTotal)
        {
            int total = SplitHand.Where(x => x.Label != "Ace").Sum(x => x.Value[0]);
            List<Card> Aces = [.. SplitHand.Where(x => x.Label == "Ace")];
            foreach (Card card in Aces)
            {
                total = total + (total + card.Value[0] > 21 ? card.Value[1] : card.Value[0]);
                card.Value[1] = 0;
            }
            return total;
        }

        public bool CanSplit()
        {
            return Hand.Count == 2 && Hand[0] == Hand[1];
        }

        public bool CanDoubleDown()
        {
            return GetTotal() > Constants.doubleDownRange[0] && GetTotal() < Constants.doubleDownRange[1] && Bet * 2 <= Money && !HasSplit;
        }

        public new void AddCard(Card? card)
        {
            if (card != null) SplitHand.Add(card);
            if (GetTotal() > 21 || GetTotal(true) > 21) SetState(UserState.Busted);
        }

        public void Hit(Deck deck, bool splitHit)
        {
            if (State != Constants.UserState.Standing && State != UserState.Busted && deck.Value.Count > 0 && !(AceSplit && SplitHand.Count > 1))
            {
                AddCard(deck.Draw());
                if (Hand.Count >= 2) SetState(UserState.Playing);
            }
        }

        public void DoubleDown(Deck deck)
        {
            if (CanDoubleDown())
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
                AddCard(Hand[0]);
                if (Hand[0].Label == "Ace") AceSplit = true;
                HasSplit = true;
                SetCards([Hand[0]]);
            }
        }

        public void Surrender()
        {
            SetBet(Bet / 2);
            Stand();
        }
    }
}
