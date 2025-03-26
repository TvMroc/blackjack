using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Blackjack
{
    class User
    {
        public List<Card> Cards { get; private set; } = [];
        public int Money { get; private set; }
        public int Bet { get; private set; } = 0;
        public bool Standing { get; private set; } = false;
        public bool Busted()
        {
            return GetTotal() > 21;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void SetCards(List<Card> cards)
        {
            Cards = cards;
        }
        public void SetMoney(int money)
        {
            Money = money;
        }
        public void SetBet(int bet)
        {
            Bet = bet;
        }

        public void Stand()
        {
            Standing = true;
        }
        public void Hit(Deck deck)
        {
            if (!Standing && deck.Value.Count > 0)
            AddCard(deck.Draw());
        }
        public User(int money)
        {
            Money = money;
        }

        public int GetTotal()
        {
            int total = Cards.Where(x => x.Label != "Ace").Sum(x => x.Value[0]);
            List<Card> Aces = Cards.Where(x => x.Label == "Ace").ToList();
            foreach (Card card in Aces)
            {
                total = total + (total + card.Value[0] > 21 ? card.Value[1] : card.Value[0]);
            }
            return total;
        }
    }
}
