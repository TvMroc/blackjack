using static test.Blackjack.Constants;

namespace test.Blackjack
{
    class Player : User
    {
        public List<Card> SplitHand { get; private set; } = [];
        private bool AceSplit = false;
        public UserState SplitHandState = UserState.Playing;
        public bool HasSplit { get; private set; } = false;
        public bool DoubledDown { get; private set; } = false;
        public bool SplitDoubledDown { get; private set; } = false;
        public bool SplitMove { get; private set; } = false;

        public Player(int money, string name) : base(money, name) { }

        public int GetTotal()
        {
            return CalculateTotal(Hand);
        }

        public int GetSplitTotal()
        {
            return CalculateTotal(SplitHand);
        }
        public int GetCurrentTotal()
        {
            return SplitMove ? GetSplitTotal() : GetTotal();
        }

        private int CalculateTotal(List<Card> hand)
        {
            int total = hand.Where(x => x.Label != "Ace").Sum(x => x.Value[0]);
            List<Card> Aces = hand.Where(x => x.Label == "Ace").ToList();
            foreach (Card card in Aces)
            {
                total = total + (total + card.Value[0] > 21 ? card.Value[1] : card.Value[0]);
            }
            return total;
        }

        public bool CanSplit()
        {
            return Hand.Count == 2 && Hand[0].Label == Hand[1].Label;
        }

        public bool CanDoubleDown()
        {
            int total = GetCurrentTotal();
            return total >= Constants.doubleDownRange[0] && total <= Constants.doubleDownRange[1] && Bet * 2 <= Money;
        }

        public new void AddCard(Card? card)
        {
            if (card != null)
            {
                if (SplitMove) SplitHand.Add(card);
                else Hand.Add(card);
            }

            if (GetCurrentTotal() > 21)
                SetState(UserState.Busted);
        }

        public void Hit(Deck deck)
        {
            if (State != UserState.Standing && State != UserState.Busted && deck.Value.Count > 0 && !(AceSplit && SplitHand.Count > 1))
            {
                AddCard(deck.Draw());
                if (!SplitMove && Hand.Count >= 2)
                    SetState(UserState.Playing);
            }
        }

        public void DoubleDown()
        {
            if (CanDoubleDown())
            {
                SetBet(Bet * 2);
                SetState(UserState.RequestingCard);
                if (!SplitMove) 
                {
                    DoubledDown = true;
                }
                else SplitDoubledDown = true;
            }
            else
            {
                Console.WriteLine("Not enough money");
            }
        }

        public void Split()
        {
            if (!CanSplit()) return;

            Card secondCard = Hand[1];
            SplitHand = new List<Card> { secondCard };
            SetCards(new List<Card> { Hand[0] });

            HasSplit = true;
            SplitMove = false;

            if (Hand[0].Label == "Ace") AceSplit = true;
            SetState(UserState.RequestingCard);
        }

        public void Surrender()
        {
            SetBet(Bet / 2);
            Stand();
        }

        public void SetSplitMove(bool isSplitMove)
        {
            SplitMove = isSplitMove;
        }
    }
}
