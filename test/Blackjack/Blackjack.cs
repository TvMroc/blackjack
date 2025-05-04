using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static test.Blackjack.Constants;
using static test.Blackjack.Deck;
using static test.Blackjack.Player;

namespace test.Blackjack
{
    class Blackjack
    {
        private string? user;
        private Player player = new Player(Constants.startMoney);
        private Dealer dealer = new Dealer(Constants.startMoney);
        public string Winner { get; private set; } = "";
        
        Deck deck = new Deck();

        public List<Card> GetCards(string user)
        {
            if ((Winner != "" || this.user == user) && user == "player") return player.Hand;
            if ((Winner != "" || this.user == user) && user == "dealer") return dealer.Hand;
            return new List<Card> { };
        }

        public int GetCardCount(string user)
        {
            if (user == "player") return player.Hand.Count;
            return dealer.Hand.Count;

        }
        public int GetTotalFor(string totalFor)
        {
            if ((Winner != "" || user == totalFor) && totalFor == "player") return player.GetTotal();
            if ((Winner != "" || user == totalFor) && totalFor == "dealer") return dealer.GetTotal();
            return 0;
        }

        private string CurrentActor = "dealer";

        public void UpdateBusted()
        {
            if (player.GetTotal() > 21) player.SetState(UserState.Busted);
            if (dealer.GetTotal() > 21) dealer.SetState(UserState.Busted);
        }

        public bool NextAction()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Standing )
                {
                    if (user == "dealer" && dealer.State != UserState.Busted && dealer.State != UserState.Standing)
                    {
                        return true;
                    } else
                    {
                        if (dealer.GetTotal() < 16) 
                        {
                            dealer.SetState(UserState.RequestingCard);
                        } else
                        {
                            dealer.Stand();
                        }

                    }
                }
            }
            else
            {
                if (player.State != UserState.Standing)
                {
                    if (user == "player" && player.State != UserState.Busted && player.State != UserState.Standing)
                    {
                        return true;
                    }
                    else
                    {
                        if (player.GetTotal() < 16)
                        {
                            if (player.CanSplit()) player.Split();
                            if (player.CanDoubleDown()) player.DoubleDown(deck);
                            player.SetState(UserState.RequestingCard);
                        }
                        else
                        {
                            player.Stand();
                        }
                    }
                }
            }
            if ((dealer.State == UserState.Standing || dealer.State == UserState.Busted) && (player.State == UserState.Standing || player.State == UserState.Busted))
            {
                if ((dealer.State == UserState.Busted && player.State == UserState.Busted) || (player.GetTotal() == dealer.GetTotal()))
                {
                    Winner = "Draw ";
                }
                else if (dealer.State == UserState.Busted && player.State != UserState.Busted || player.State != UserState.Busted && player.GetTotal() > dealer.GetTotal())
                {
                    Winner = "Player";
                }
                else if (player.State == UserState.Busted && dealer.State != UserState.Busted || dealer.State != UserState.Busted && dealer.GetTotal() > player.GetTotal()) Winner = "Dealer";
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
            return false;
        }
        public UserState GetState(string user)
        {
            if (user == "player") return player.State;
            return dealer.State;
        }

        public void Shuffle()
        {
            deck.Shuffle();
        }

        public void Deal(string user)
        {
            if (user == "player") player.Hit(deck);
            if (user == "dealer") dealer.Hit(deck);
        }

        public void Dealing()
        {
            dealer.SetState(UserState.RequestingCard);
            player.SetState(UserState.RequestingCard);
        }

        public void Hit()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Standing && dealer.State != UserState.Busted) dealer.SetState(UserState.RequestingCard);
            }
            else
            {
                if (player.State != UserState.Standing && player.State != UserState.Busted) player.SetState(UserState.RequestingCard);
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
        }

        public void Stand()
        {
            if (CurrentActor == "dealer")
            {
                if (dealer.State != UserState.Busted) dealer.Stand();
            }
            else
            {
                if (player.State != UserState.Busted) player.Stand();
            }
            CurrentActor = CurrentActor == "dealer" ? "player" : "dealer";
        }

        public void StartGame(string user)
        {
            Winner = "";
            this.user = user;
            deck = new Deck();
            player = new Player(Constants.startMoney);
            dealer = new Dealer(Constants.startMoney);
        }
    }
}
