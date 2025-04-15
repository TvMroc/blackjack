using static test.Blackjack.Constants;

namespace test.Blackjack
{
    class User
    {
        public List<Card> Hand { get; private set; } = [];
        public int Money { get; private set; }
        public int Bet { get; private set; } = 0;
        public UserState State { get; private set; } = UserState.Playing;

        public void AddCard(Card? card)
        {
            if (card != null) Hand.Add(card);
            if (GetTotal() > 21) State = UserState.Busted;
        }

        public void SetCards(List<Card> cards) => Hand = cards;
       
        public void SetMoney(int money) => Money = money;
        
        public void SetBet(int bet) => Bet = bet;
      
        public void SetState(UserState state) => State = state;

        public void Stand()
        {
            State = UserState.Standing;
        }
        public void Hit(Deck deck)
        {
            if (State != UserState.Standing && State != UserState.DoubledDown && deck.Value.Count > 0)
            AddCard(deck.Draw());
        }
        public User(int money)
        {
            Money = money;
        }

        public int GetTotal()
        {
            int total = Hand.Where(x => x.Label != "Ace").Sum(x => x.Value[0]);
            List<Card> Aces = Hand.Where(x => x.Label == "Ace").ToList();
            foreach (Card card in Aces)
            {
                total = total + (total + card.Value[0] > 21 ? card.Value[1] : card.Value[0]);
            }
            return total;
        }
    }
}
