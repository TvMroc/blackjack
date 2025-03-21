using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Blackjack
{
    class User
    {
        private List<Card> Cards = [];

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void SetCards(List<Card> cards)
        {
            Cards = cards;
        }

        public List<Card> GetCards()
        {
            return Cards;
        }
    }
}
